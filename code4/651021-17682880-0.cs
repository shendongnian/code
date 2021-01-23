    List<Task> m = new List<Task>();
    private async void cmdLogin_Click(object sender, EventArgs e)
    {
        bool result = imapMail.Connection();
        if (result)
        {
            result = imapMail.LogIn(email, password);
            if (result)
            {
                foreach (ImapX.Message msgs in imapMail.Folders[inbox].Messages)
                {
                    m.Add(new Task(new Action(() => msgs.Process())));
                }
                await Task.WhenAll(m);
                
                var messes = imapMail.Folders[inbox].Messages;
                foreach (var x in messes)
                {
                    string from = "";
                    foreach (var addresses in x.From)
                    {
                        from = addresses.DisplayName;
                    }
                    listBox1.Items.Add(from + ": " + x.Subject);
                }
            }
            else { this.Text = "failed login"; }
        }
        else { this.Text = "Failed connection"; }
    }
