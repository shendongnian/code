        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 i; //create a integer variable 
            for (i = 1; i <= 10; i++) // will generate 10 LinkButton 
            {
                LinkButton lb = new LinkButton(); //create instance of LinkButton 
                lb.Text = Convert.ToString(i) + "&nbsp;"; //LinkButton Text 
                lb.ID = Convert.ToString(i); // LinkButton ID’s 
                lb.CommandArgument = Convert.ToString(i); // LinkButton CommandArgument 
                lb.CommandName = Convert.ToString(i); // LinkButton CommanName 
                //lb.Click += lb_Click; //Create Handler for it.
                lb.Command += lb_Command;
                //type lb.Command += and press double time Tab Key it will generat the lb_Command() code 
                form1.Controls.Add(lb); // Adding the LinkButton in PlaceHolder 
            } 
        }
        void lb_Command(object sender, CommandEventArgs e)
        {
            Label1.Text = e.CommandName; // will display the which Linkbutton clicked             
        }
