    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            m_uc1 = new UserControl1();
            elementHost1.Child = m_uc1;
        }
        private UserControl1 m_uc1;
        private void button1_Click(object sender, EventArgs e)
        {
            string rawXamlText = File.ReadAllText(@"in.txt");
            var flowDocumentStringReader = new StringReader(rawXamlText);            
            var flowDocumentTextReader = new XmlTextReader(flowDocumentStringReader);           
            object document = XamlReader.Load(flowDocumentTextReader);
            var fd = document as FlowDocument;
            
            m_uc1.docReader.Document = fd;
            
            flowDocumentTextReader.Close();
            flowDocumentStringReader.Close();
            flowDocumentStringReader.Dispose();
          
        }        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (elementHost1 != null)
            {
                elementHost1.Child = null;
                elementHost1.Dispose();
                elementHost1.Parent = null;
                elementHost1 = null;
            }
        }
