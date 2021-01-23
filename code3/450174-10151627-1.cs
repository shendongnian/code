    foreach (Chat chat in skype.Chats)
    {
        if (messagespam_bool == false)
        {
            numericUpDown1.Value = 0;
            break;
        }
        try
        {
                String contact = listBox1.SelectedItem.ToString();
                SendAndCount(contact, textBox7.Text); //1st message
                SendAndCount(contact, textBox7.Text); //2nd message
                SendAndCount(contact, textBox7.Text); //3rd message
                SendAndCount(contact, textBox7.Text); //4th message
            }
        catch (Exception error)
        {
            MessageBox.Show(error.Message);
        }
        break;
    }
