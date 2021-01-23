    public class JqGridColumnMultipleEditableAttribute : JqGridColumnEditableAttribute
    {
        public bool Multiple { get; set; }
        protected override IDictionary<string, object> HtmlAttributes
        {
            get
            {
                if (Multiple)
                    return new Dictionary<string, object>() { { "multiple", "multiple" } };
                else
                    return null;
            }
        }
        public JqGridColumnMultipleEditableAttribute(bool editable)
            : base(editable)
        {
            Multiple = false;
        }
        public JqGridColumnMultipleEditableAttribute(bool editable, string dataUrlRouteName)
            : base(editable, dataUrlRouteName)
        {
            Multiple = false;
        }
        public JqGridColumnMultipleEditableAttribute(bool editable, string dataUrlAction, string dataUrlController) :
            this(editable, dataUrlAction, dataUrlController, null)
        { }
        public JqGridColumnMultipleEditableAttribute(bool editable, string dataUrlAction, string dataUrlController, string dataUrlAreaName)
            : base(editable, dataUrlAction, dataUrlController, dataUrlAreaName)
        {
            Multiple = false;
        }
    }
