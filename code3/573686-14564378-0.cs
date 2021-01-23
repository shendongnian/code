        [
        Bindable(false),
        Category("Appearance"),
        DefaultValue("pagination pagination-centered"),
        Description("Css class for the surrounding div")
        ]
        public virtual string CssClass {
            get {
                if (ViewState["CssClass"] == null) {
                    ViewState["CssClass"] = "pagination pagination-centered";
                }
                return (string)ViewState["CssClass"];
            }
            set {
                ViewState["CssClass"] = value;
            }
        }
        protected override HtmlTextWriterTag TagKey {
            get {
                    return HtmlTextWriterTag.Div;
            }
        }
        protected override void AddAttributesToRender(HtmlTextWriter writer) {
                if (HasControls()) {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, CssClass);
                }
        }
        protected override void RenderContents(HtmlTextWriter writer) {
            if (HasControls()) {
                writer.RenderBeginTag(HtmlTextWriterTag.Ul);
                foreach (Control child in Controls) {
                    var item = child as DataPagerFieldItem;
                    if (item == null || !item.HasControls()) {
                        child.RenderControl(writer);
                        continue;
                    }
                    foreach (Control ctrl in item.Controls) {
                        var space = ctrl as LiteralControl;
                        if (space != null && space.Text == "&nbsp;")
                            continue;
                        // Set specific classes for li-Tag
                        if (ctrl is System.Web.UI.WebControls.WebControl) {
                            // Enabled = false -> "disabled"
                            if (!((System.Web.UI.WebControls.WebControl)ctrl).Enabled) {
                                writer.AddAttribute(HtmlTextWriterAttribute.Class, "disabled");
                            }
                            // there can only be one Label in the datapager -> "active"
                            if (ctrl is System.Web.UI.WebControls.Label) {
                                writer.AddAttribute(HtmlTextWriterAttribute.Class, "active");
                            }
                        }
                        writer.RenderBeginTag(HtmlTextWriterTag.Li);
                        ctrl.RenderControl(writer);
                        writer.RenderEndTag();
                    }
                }
                writer.RenderEndTag();
            }
       }
