    private int count;
    private void SendAndCount(Contact contact, String text)
    {
       // add your count logic here
       count++;
       skype.SendMessage(contact, textBox7.Text); 
    }
