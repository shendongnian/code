    public partial class ucOpleiding : UserControl
    {
       public string Datum
       {
            get { return txtDatum.Text; }
            set { txtDatum.Text = value; }
       }
       public string Plaats
       {
           get { return txtPlaats.Text; }
           set { txtPlaats.Text = value; }
       }
       public string Omschrijving
       {
           get { return txtOmschrijving.Text; }
           set { txtOmschrijving.Text = value; }
       }
        public ucOpleiding()
        {
            InitializeComponent();
        }
