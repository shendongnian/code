    public void buttonHandler(object sender, EventArgs e)
    {
       Button btn=sender as Button;
       string Id_Of_Your_Clicked_Button = btn.Name;
       // You should generate a unique ID/Name for each button during control generation.
       ....
    }
