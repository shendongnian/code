    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:NumberBox runat=server></{0}:NumberBox>")]
    public sealed class NumberBox : BaseInputBox
    {
        public override TextBoxMode TextMode
        {
            get
            {
                return TextBoxMode.SingleLine;
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            RegisterIncludeScripts();
            this.Attributes.Add("onkeydown", "return NumberBox_KeyDown(this, event);");
            this.Attributes.Add("onkeyup", "return NumberBox_KeyUp(this, event);");
            this.Attributes.Add("onblur", "NumberBox_Blur(this);");
            this.Attributes.Add("onpaste", "NumberBox_Paste(this);");
            if (MaxLength > 0)
            {
                this.Attributes.Add("maxLength", this.MaxLength.ToString());
            }
            this.Attributes.Add("minValue", this.MinValue.ToString());
            this.Attributes.Add("maxValue", this.MaxValue.ToString());
            base.OnPreRender(e);
        }
        private void RegisterIncludeScripts()
        {
            this.Page.ClientScript.RegisterClientScriptResource(typeof(TextArea), "StrataSoft.StrataDial.Web.Controls.Javascript.NumberBox.js");
        }
        [Bindable(true),
        Category("Validation"),
        DefaultValue("")]
        public int MinValue
        {
            get { return (int)(ViewState["MinValue"] ?? int.MinValue); }
            set { ViewState["MinValue"] = value; }
        }
        [Bindable(true),
        Category("Validation"),
        DefaultValue("")]
        public int MaxValue
        {
            get { return (int)(ViewState["MaxValue"] ?? int.MaxValue); }
            set { ViewState["MaxValue"] = value; }
        }
        public int Number
        {
            get
            {
                if (this.Text.Equals(String.Empty))
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(this.Text);
                }
            }
        }
    }
