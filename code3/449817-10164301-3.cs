    for (int i = 0; i < skype.Chats.Count; i++)
    {
        try
        {
            listBox1.Items.Add(skype.Chats[0].Name);
        }
        catch (Exception) {}
    }
