    public partial class ApplicationProperties : Form
    {
        public event EventHandler SaveRequested;
    
        public SomeObjectType Portbx        {get;set;}
        public SomeObjectType BaudRatebx    {get;set;}
        public SomeObjectType DataBitsbx    {get;set;}
        public SomeObjectType Paritybx      {get;set;}
        public SomeObjectType StopBitsbx    {get;set;}
        public SomeObjectType Handshakingbx { get; set; }
        
        public ApplicationProperties()
        {
            InitializeComponent();
        }
    
        private void CommPortAcceptbtn_Click(object sender, EventArgs e)
        {
            if (SaveRequested != null)
                SaveRequested(this, new EventArgs());
        }
    }
    public partial class MainBox : Form
    {
        ApplicationProperties ApplicationPropertiesWindow;
        public MainBox()
        {
            InitializeComponent();
            ApplicationPropertiesWindow = new ApplicationProperties();
            ApplicationPropertiesWindow.SaveRequested += ApplicationPropertiesWindow_SaveRequested;
        }
    
        void ApplicationPropertiesWindow_SaveRequested(object sender, EventArgs e)
        {
            ApplicationPropertiesWindow.Hide();
            SaveApplicationProperties();
        }
    
        public void SaveApplicationProperties()
        {
    
            try
            {
                //CreateNode(everything being referenced. Put text boxes, and drop down boxes here.
                XmlTextWriter writer = new XmlTextWriter(@"C:\ForteSenderv3.0\Properties.xml", System.Text.Encoding.UTF8);
                writer.WriteStartDocument(true);
                //Making the code indeted by 2 characters.
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                //Making the start element "Table".
                writer.WriteStartElement("Forte_Data_Gatherer_Application");
                //Calling the rst of the .xml file to write.
                CreateNode(
                    ApplicationPropertiesWindow.Portbx.SelectedItem.ToString(), 
                    ApplicationPropertiesWindow.BaudRatebx.SelectedItem.ToString(), 
                    ApplicationPropertiesWindow.DataBitsbx.SelectedItem.ToString(), 
                    ApplicationPropertiesWindow.Paritybx.SelectedItem.ToString(), 
                    ApplicationPropertiesWindow.StopBitsbx.SelectedItem.ToString(), 
                    ApplicationPropertiesWindow.Handshakingbx.SelectedItem.ToString(), 
                    writer);
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Writing to .xml file failure: " + ex.Message);
            }
        }
    }
