    public partial class DynamicControlsOnDemand : System.Web.UI.Page
    {
        public int NumberOfControls
        {
            get
            {
                if (this.ViewState["d"] == null)
                {
                    return 0;
                }
                return int.Parse(this.ViewState["d"].ToString());
            }
            set
            {
                this.ViewState["d"] = value;
            }
        }
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            this.CreateDynamicControls();
        }
        protected void addControl_Click(object sender, EventArgs e)
        {
            this.NumberOfControls = this.NumberOfControls + 1;
            this.myPanel.Controls.Add(this.CreateTextbox(this.NumberOfControls));
        }
        private void CreateDynamicControls()
        {
            for (int i = 0; i < this.NumberOfControls; i++)
            {
                var t = this.CreateTextbox(i + 1);
                t.TextChanged += (x, y) => this.lblMessage.Text += "<br/>" + (x as TextBox).ID + " " + (x as TextBox).Text;
                this.myPanel.Controls.Add(t);
            }
        }
        private TextBox CreateTextbox(int index)
        {
            var t = new TextBox { ID = "myTextbox" + index.ToString(), Text = "de" };
            return t;
        }
    }
