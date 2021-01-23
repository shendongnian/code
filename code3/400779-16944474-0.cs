    public class TextBoxWithType : TextBox
    {
        public string modifyType { get; set; }
        protected override void Render(System.Web.UI.HtmlTextWriter output)
        {
            if (!string.IsNullOrEmpty(modifyType))
            {
                output.AddAttribute("type", modifyType);
            }
            base.Render(output);
        }
    }
