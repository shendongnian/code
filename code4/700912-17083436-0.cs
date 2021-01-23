    public class MyClass
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void fetchContactList()
        {
            // Define string of list
            List<string> lstContacts = new List<string>();
            
            // Below requestsetting class take 3 parameters applicationname, gmail username, gmail password. Provide appropriate Gmail account details
            RequestSettings rsLoginInfo = new RequestSettings("", textBox1.Text, textBox2.Text);
            rsLoginInfo.AutoPaging = true;
            ContactsRequest cRequest = new ContactsRequest(rsLoginInfo);
            // fetch contacts list
            Feed<Contact> feedContacts = cRequest.GetContacts();
           
            //dataGridView1.ColumnCount = 1;
            //dataGridView1.Columns[0].Name = "Product ID";
            // looping the feedcontact entries
            try
            {
               // dataGridView1.Columns.Add("Name", "Name");
                RichTextBox rtb = new RichTextBox();
                string email = "";
                DataTable dt = new DataTable();
                dt.Columns.Add("Email Address");
                foreach (Contact gmailAddresses in feedContacts.Entries)
                {
                    // Looping to read email addresses
                    foreach (EMail emailId in gmailAddresses.Emails)
                    {
                       dt.Rows.Add(new object[] {email=emailId.Address});
                       dataGridView1.DataSource = dt;  
                    }
                    
                    dataGridView1.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Please enter the correct credentials","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                //throw;
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            fetchContactList();
        }
    }
}
