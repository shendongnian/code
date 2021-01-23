    protected void BindResult(object sender, EventArgs e)
    {
        CheckBox check = sender as CheckBox;
        switch (check.Text)
        {
            case "1": 
                /* 
                    * 1. Execute - Select * from Table1
                    * 2. Bind the DataSource to Repeater1
                    */
                /* Shows the first View*/
                MultiView1.ActiveViewIndex = 0;
                break;
            case "2":
                /* 
                    * 1. Execute - Select * from Table2
                    * 2. Bind the DataSource to Repeater2
                    */
                /* Shows the second View*/
                MultiView1.ActiveViewIndex = 1;
                break;
        }
    }
