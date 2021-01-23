    public partial class Form1 : Form
    {
        XDocument doc;
        public Form1()
        {
            InitializeComponent();
            doc = XDocument.Load(apppath + @"\Contacts.clf");
            var entryNames = doc.Root.Elements("EntryName")
                .Select(elem => elem.Element("Name").Value ).ToArray();
            listBox1.Items.AddRange(entryNames);
        }
        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = doc.Root.Elements("EntryName")
                .FirstOrDefault(node => node.Element("Name").Value == listBox1.SelectedItem.ToString())
                .Element("Email").Value;
            
        }
    }
