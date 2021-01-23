        protected void Page_Load(object sender, EventArgs e)
        {
            getRadioValue(this.Controls, "Hello");
        }
        private string getRadioValue(ControlCollection clts, string groupName)
        {
            string ret = "";
            foreach (Control ctl in clts)
            {
                if (ctl.Controls.Count != 0)
                {
                    if (ret == "")
                        ret = getRadioValue(ctl.Controls, groupName);
                }
                if (ctl.ToString() == "System.Web.UI.WebControls.RadioButton")
                {
                    RadioButton rb = (RadioButton)ctl;
                    if (rb.GroupName == groupName && rb.Checked == true)
                        ret = rb.Attributes["Value"];
                }
            }
            return ret;
        }
