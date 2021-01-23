    private void messagespam_worker_DoWork(object sender, DoWorkEventArgs e)
            {
                for (int i = 1; i < numericUpDown1.Value; i++)
                    Invoke((MethodInvoker)delegate
        {
            foreach (Chat chat in skype.Chats)
            {
                if (messagespam_bool == false)
                {
                    numericUpDown1.Value = 0;
                    break;
                }
                try
                {
                       toolStripStatusLabel3.Text = "- Sent: " + i*4; // 4 is the number of messages, better keep it in a variable
        
                        String contact = listBox1.SelectedItem.ToString();
                        skype.SendMessage(contact, textBox7.Text); //1st message
                        toolStripStatusLabel3.Text = "- Sent: " + i*4 + 1; // remove this if this is not required
                        skype.SendMessage(contact, textBox7.Text); //2nd message
    toolStripStatusLabel3.Text = "- Sent: " + i*4 + 2;
                        skype.SendMessage(contact, textBox7.Text); //3rd message
    toolStripStatusLabel3.Text = "- Sent: " + i*4 + 3;
                        skype.SendMessage(contact, textBox7.Text); //4th message
                    }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                break;
            }
        
        
        });
            }
