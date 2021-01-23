        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Test"] = "Tester";
            //Should be longer than the 1 minute session timeout
            Thread.Sleep(120001);
            Response.Write(String.Format("Session[\"Test\"] = {0}", Session["Test"]));
        }
