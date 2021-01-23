    public partial class ucSignature : UserControl
    {
        public ucSignature()
        {
            InitializeComponent();
        }
        private void inkCanvas1_LostMouseCapture(object sender, MouseEventArgs e)
        {
            var sb = new StringBuilder();
            using (var ms = new MemoryStream())
            {
                inkCanvas1.Strokes.Save(ms);
                foreach (var item in ms.ToArray())
                {
                    sb.AppendFormat("{0},", item);
                }
                ms.Close();
            }
            var local = sb.ToString().Trim() + "¬¬¬";
            local = local.Replace(",¬¬¬", string.Empty);
            this.SetValue(SignatureProperty, local);
        }
        private void LoadSignature(string signatureIn)
        {
            if (string.IsNullOrEmpty(signatureIn) || !signatureIn.Contains(",")) return;
            var x = signatureIn.Split(',').Select(byte.Parse).ToArray();
            if (!x.Any()) return;
            using (var ms = new MemoryStream(x))
            {
                inkCanvas1.Strokes = new StrokeCollection(ms);
                ms.Close();
            }
        }
        public static DependencyProperty SignatureProperty = DependencyProperty.Register(
            "Signature",
            typeof(string),
            typeof(ucSignature),
            new UIPropertyMetadata(OnSignaturePropertyChanged));
        public static string GetSignature(ucSignature signature)
        {
            return (string)signature.GetValue(SignatureProperty);
        }
        public static void SetSignature(ucSignature signature, string value)
        {
            signature.SetValue(SignatureProperty, value);
        }
        private static void OnSignaturePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var signature = obj as ucSignature;
            if (signature != null)
            {
                LoadSignature(args.NewValue.ToString());
            }
        }
       
        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            this.SetValue(SignatureProperty, "0,136,3,3,6,72,16,69,53,70,53,17,0,0,128,63,31,9,17,0,0,0,0,0,0,240,63,10,237,2,186,1,135,240,12,39,128,97,109,28,4,156,51,90,235,138,135,131,227,95,107,253,119,193,35,104,195,186,246,103,1,195,179,59,78,134,195,179,92,167,188,180,76,206,211,192,77,175,108,211,28,53,136,32,51,41,156,210,3,148,109,22,188,163,105,195,188,11,92,11,184,122,101,188,166,182,124,53,106,153,90,44,217,71,15,64,102,115,59,52,205,105,1,53,128,76,166,179,73,156,202,107,0,195,248,122,106,153,64,22,185,164,210,3,51,154,64,102,51,8,5,174,105,52,128,204,102,19,57,156,215,41,90,69,162,103,1,128,76,128,19,40,4,6,1,102,153,205,96,22,105,156,206,101,53,180,89,230,83,88,4,202,107,0,179,38,120,122,215,52,195,248,120,179,101,25,158,80,195,179,41,156,210,107,50,180,205,38,144,25,156,214,105,52,153,97,249,165,166,101,52,180,205,32,48,0,135,231,164,231,113,153,131,40,225,168,4,6,1,1,128,89,160,22,105,164,214,207,135,32,56,110,3,52,153,192,96,19,80,0,11,68,6,1,105,11,76,2,215,135,50,142,28,77,48,253,160,180,225,232,12,2,107,52,128,205,38,115,91,68,214,105,51,153,77,112,238,30,77,102,80,9,148,214,1,1,154,76,230,64,38,80,8,12,2,101,50,180,205,11,70,29,128,225,236,63,0,153,77,96,19,9,141,154,207,102,153,204,230,19,24,12,209,105,154,64,96,19,89,148,204,0,76,166,118,121,132,204,77,38,179,56,13,170,3,51,128,64,109,24,126,104,154,32,54,121,148,202,103,52,153,77,96,9,144");
        }
        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas1.Strokes.Clear();
            this.SetValue(SignatureProperty, string.Empty);
        }
    }
