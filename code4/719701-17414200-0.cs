    public void get_value(object sender, GridRecordEventArgs e)
        {
            Session["emailAddress"]= e.Record["emailAddress"].ToString();
        }
    protected void btnsendMail_Click(object sender, EventArgs e)
        {
    
          //you can use this  
    string _myEmail=Session["emailAddress"];
         }
