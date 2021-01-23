    namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List<string> Clients = new List<string>();
        public Form1()
        {
            InitializeComponent();
            Clients.Add("Jack");
            Clients.Add("Sandra");
            Clients.Add("Anna");
            Clients.Add("Tom");
            Clients.Add("Bob");
        }
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            if (txtAddClient.Text == "")
            {
                MessageBox.Show("No client name has been entered!");
            }
            else
            {
                string msg = "";
                
                
                
                string newClient = txtAddClient.Text;
                Clients.Add(newClient);
                foreach (string val in Clients)
                {
                    msg += "- " + val + "\n";
                }
                MessageBox.Show(msg);
            }
        }
    }
