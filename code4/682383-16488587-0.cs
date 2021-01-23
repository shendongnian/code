    [ParseChildren(true)]
    [PersistChildren(true)]
    [ToolboxData(@"<{0}:JsRegistererForVB runat=""server""></{0}:JsRegistererForVB>")]
    public class JsRegistererForValidationBase : WebControl, INamingContainer
    {
        private ValidationFieldCollection _children;
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ValidationFieldCollection Children
        {
            get
            {
                if (_children == null)
                    _children = new ValidationFieldCollection();
                return _children;
            }
        }
        protected override void CreateChildControls()
        {
            Controls.Clear();
            foreach (var c in _children)
                Controls.Add(c);
        }
        protected override void OnInit(EventArgs e)
        {
            //DO THE REGISTER STUFF
            base.OnInit(e);
        }
        protected override void Render(HtmlTextWriter writer)
        {
            RenderChildren(writer);
        }
    }
    public class ValidationFieldCollection : List<ValidationBase> { }
}
