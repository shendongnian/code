    public void HandleCustomEvent(object sender, MyCustomeEventArgs e)
    {
        GetAllItemsByRegistrantID(e.SearchID);
    }
    
    public void GetAllItemsByRegistrantID(int id)
    {
        Label1.Text = id.ToString();
    }
