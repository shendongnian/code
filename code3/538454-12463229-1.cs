    protected void Page_Load(object sender, EventArgs e)
		{
			// ..... your other code
                        if(DateTime.Now >= new DateTime(2012, 10, 13) ){
                              mbcRadioList.Visible = true;
                        }
		}
