        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                LinkButton lnk1 = new LinkButton();
                lnk1.ID = "D1";
                lnk1.Text = "A";
                //Event handler must be registered in the Page_Load/Page_Init
                lnk1.Click += new EventHandler(LinkButton_Click);
                plhDynamicLinks.Controls.Add(lnk1);
                LinkButton lnk2 = new LinkButton();
                lnk2.ID = "D2";
                lnk2.Text = "B";
                lnk2.Click += new EventHandler(LinkButton_Click);
                plhDynamicLinks.Controls.Add(lnk2);
                LinkButton lnk3 = new LinkButton();
                lnk3.ID = "D3";
                lnk3.Text = "C";
                lnk3.Click += new EventHandler(LinkButton_Click);
                plhDynamicLinks.Controls.Add(lnk3);
                LinkButton lnk4 = new LinkButton();
                lnk4.ID = "D4";
                lnk4.Text = "D";
                lnk4.Click += new EventHandler(LinkButton_Click);
                plhDynamicLinks.Controls.Add(lnk4);
            }
        }
        
        protected void LinkButton_Click(object sender, EventArgs e)
        {
            PopulateLinksBasedOnCriteria();
            LinkButton clickedControl = (LinkButton)sender;
            Response.Write(DateTime.Now.ToString()+"___"+ clickedControl.ID + " Link Button Clicked" );
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            PopulateLinksBasedOnCriteria();
        }
        private void PopulateLinksBasedOnCriteria()
        {
            plhDynamicLinks.Controls.Clear();
            if (DateTime.Now.Second < 30)
            {
                LinkButton linkButton1 = new LinkButton();
                linkButton1.ID = "D1";
                linkButton1.Text = "1";
                plhDynamicLinks.Controls.Add(linkButton1);
                LinkButton linkButton2 = new LinkButton();
                linkButton2.ID = "D2";
                linkButton2.Text = "2";
                plhDynamicLinks.Controls.Add(linkButton2);
            }
            else
            {
                LinkButton linkButton3 = new LinkButton();
                linkButton3.ID = "D3";
                linkButton3.Text = "3";
                plhDynamicLinks.Controls.Add(linkButton3);
                LinkButton linkButton4 = new LinkButton();
                linkButton4.ID = "D4";
                linkButton4.Text = "4";
                plhDynamicLinks.Controls.Add(linkButton4);
            }
        }
