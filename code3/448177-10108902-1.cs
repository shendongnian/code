        MasterPage MP;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //Setting the master page
            MP = ((WebApplicationTemplate.MasterPage)Master);
        }
        protected void Foo()
        {
            //Accessing a MasterPage control
            MP.Bar.Visible = false;
        }
