    public partial class Form1 : Form
    {
        XDocument doc;
        public Form1()
        {
            InitializeComponent();
            String apppath = ".";
            doc = XDocument.Load(apppath + @"\Contacts.clf");
            var contacts = doc.Root.Elements("EntryName")
                .Select( elem =>
                    new Contact { 
                        Name =  elem.Element("Name").Value,
                        Email = elem.Element("Email").Value,
                        EIL = elem.Element("EIL").Value,
                        Notes = elem.Element("Notes").Value
                }
            ).ToList();
            listBox1.DataSource = contacts;
            listBox1.DisplayMember = "Name";
        }
        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = (listBox1.SelectedItem as Contact).Email;
        }        
    }
    public class Contact
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String EIL { get; set; }
        public String Notes { get; set; }
    }
