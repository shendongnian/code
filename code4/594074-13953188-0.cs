     public MainWindow()
        {
            InitializeComponent();
            TabItem tab2 = TrycloneElement(tab1);
            if (tab2 != null)
                main.Items.Add(tab2);
        }
        public static T TrycloneElement<T>(T orig)
        {
            try
            {
                string s = XamlWriter.Save(orig);
                StringReader stringReader = new StringReader(s);
                XmlReader xmlReader = XmlTextReader.Create(stringReader, new XmlReaderSettings());
                XmlReaderSettings sx = new XmlReaderSettings();
                object x = XamlReader.Load(xmlReader);
                return (T)x;
            }
            catch
            {
                return (T)((object)null);
            }
        }
