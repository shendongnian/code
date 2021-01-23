        protected void Page_Init(object sender, EventArgs e)
        {
            for (int i = 0; i < this.DynamicControlsCount; i++)
            {
                var c = this.LoadControl("~/AddressControl.ascx");
                this.addresses.Controls.Add(c);
            }
        }
        protected void addAddress_Click(object sender, EventArgs e)
        {
            this.DynamicControlsCount++;
            var c = this.LoadControl("~/AddressControl.ascx");
            this.addresses.Controls.Add(c);
        }
        protected int DynamicControlsCount
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Request.Form["numberOfControls"]))
                {
                    return 0;
                }
                return int.Parse(this.Request.Form["numberOfControls"]);
            }
            set
            {
                int temp = int.Parse(this.numberOfControls.Value);
                temp++;
                this.numberOfControls.Value = temp.ToString();
            }
        }
