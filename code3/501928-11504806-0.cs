        private void btnAddClient_Click(object sender, EventArgs e)
        {
            string msg = "";
            List<string> Clients = new List<string>();
            Clients.Add("Jack");
            Clients.Add("Sandra");
            Clients.Add("Anna");
            Clients.Add("Tom");
            Clients.Add("Bob");
            if (txtAddClient.Text == "")
            {
                MessageBox.Show("No client name has been entered!");
            }
            else
            {
                string newClient = txtAddClient.Text;
                Clients.Add(newClient);
                // this is where you want to join your string
                // AFTER you add the new client to the list
                foreach (string val in Clients)
                {
                    msg += "- " + val + "\n";
                }
                MessageBox.Show(msg);
            }
        }
