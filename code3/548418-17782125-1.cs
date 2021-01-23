    MailMessage mail = new MailMessage(txt_gmail.Text, txt_to.Text, txt_subject.Text, txt_body.Text);
            mail.Attachments.Add(new Attachment(txt_attachment.Text));
            SmtpClient client = new SmtpClient(txt_server.Text);
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential(txt_gmail.Text, txt_password.Text);
            client.EnableSsl = true;
            client.Send(mail);
            MessageBox.Show("Mail sent", "Succes", MessageBoxButtons.OK);
            foreach (Control control in this.Controls)
            {
                TextBox box = control as TextBox;
                if (box != null)
                {
                    box.Text = "";
                }
            }
        }
