    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
         
            fetchOutlookContacts();
        }
        public void fetchOutlookContacts()
        {
            
            Microsoft.Office.Interop.Outlook.Items OutlookItems;
            Microsoft.Office.Interop.Outlook.Application outlookObj;
            MAPIFolder Folder_Contacts;
            outlookObj = new Microsoft.Office.Interop.Outlook.Application();
            Folder_Contacts = (MAPIFolder)outlookObj.Session.GetDefaultFolder(OlDefaultFolders.olFolderContacts);
            OutlookItems = Folder_Contacts.Items;
            DataTable dt = new DataTable();
            dt.Columns.Add("Email Address");
            for (int i = 0; i < OutlookItems.Count; i++)
            {
                Microsoft.Office.Interop.Outlook.ContactItem contact = (Microsoft.Office.Interop.Outlook.ContactItem)OutlookItems[i + 1];
                dt.Rows.Add(new object[] { contact.Email1Address });
                dataGridView1.DataSource = dt;
            }
            dataGridView1.Show();
        
        }
    }
