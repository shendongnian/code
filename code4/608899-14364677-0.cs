     if (Page.IsPostBack && *PostBackControl.Name=="btnAdd"*)
                {
    if (DateTime.Now.Second < 30)
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
        } else
            {
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
            }
