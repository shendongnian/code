    public void UpdateUser(int userId, string userName, string userDescription){
       // code to update database here
    }
    public void button1_OnClick(object obj, EventArguments e)
    {
         UpdateUser(txtBoxUserID.Content, txtBoxNewUsername.Content, txtBoxUserDescription.Content);
         UpdateDatagrid();
    }
