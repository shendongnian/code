    protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                Control ctrl = Page.LoadControl("~/Dynamic.ascx");
                pnlBox.Controls.Add(ctrl);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            foreach (var ctrl in pnlBox.Controls)
            {
                if (ctrl is IData)
                {
                    //Grab data from the UserControl
                    string name = ((ctrl as IData).Name;
                    string ship = ((ctrl as IData).Ship;
                    //Construct the XML file from the data.
                }
            }
        }
