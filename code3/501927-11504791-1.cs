    private List<string> Clients = new List<string>(){ "Jack", "Sandra", "Anna", "Tom", "Bob"};
    private void btnAddClient_Click(object sender, EventArgs e)
    {
        string msg = "";
        if (txtAddClient.Text == "")
        {
            MessageBox.Show("No client name has been entered!");
        }
        else
        {
            string newClient = txtAddClient.Text;
            Clients.Add(newClient);
            foreach (string val in Clients)
            {
                msg += "- " + val + "\n";
            }
            MessageBox.Show(msg);
        }
    }
