    using WindowsFormsApplication1.ServiceReference1;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            const string username = "apiuser-XXXXXXXXXXXX@apiconnector.com";
            const string password = "password";
            const int addressBookId = 1;  // ID of the target address book
    
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                AddContactToAddressBook();
            }
    
            private void AddContactToAddressBook()
            {
                using (ServiceReference1.APISoapClient Client = new ServiceReference1.APISoapClient())
                {
                    APIContact Contact = new APIContact();
                    Contact.AudienceType = ContactAudienceTypes.B2B;
    
                    APIContact NewContact = Client.AddContactToAddressBook(username, password, Contact, addressBookId); // etc. etc.
    
                }
            }
        }
    }
