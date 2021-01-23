    //public property
    public string Data { get;set;}
    
    private void simpleButton1_Click(object sender, EventArgs e)
    {
       Data="Something you want to return back to 1st Form";
       this.Close();
    }
