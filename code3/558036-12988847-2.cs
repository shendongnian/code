    public sealed class NumberBox : TextBox
    {
        protected override void OnPreRender(EventArgs e)
        {
            RegisterIncludeScripts();
            this.Attributes.Add("onkeydown", "return NumberBox_KeyDown(this, event);");
            this.Attributes.Add("onkeyup", "return NumberBox_KeyUp(this, event);");
            this.Attributes.Add("onblur", "NumberBox_Blur(this);");
            this.Attributes.Add("onpaste", "NumberBox_Paste(this);");
            base.OnPreRender(e);
        }
        private void RegisterIncludeScripts()
        {
            this.Page.ClientScript.RegisterClientScriptResource(typeof(TextBox), "Web.Controls.Javascript.NumberBox.js");
        }
        public int Number
        {
            get
            {
                if (this.Text.Equals(String.Empty)) return -1;
                else return Convert.ToInt32(this.Text);
            }
        }
    }
