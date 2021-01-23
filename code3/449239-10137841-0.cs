            string service = "winmgmt";
            string server = "DFS5600";
            string labelText = string.Format("{0}_{1)_Status", server, service);
            foreach (Control ctr in this.Controls)
            {
                if (ctr is Label)
                {
                    if (ctr.Name == labelText)
                    {
                        ctr.Text = "Hello Label";
                    }
                }
            }
