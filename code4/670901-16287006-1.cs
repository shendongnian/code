    public class TabItem : Panel, IPostBackEventHandler
    {
        String clientClick = String.Empty;
        public event EventHandler Click;
        [Bindable(true)]
        [Category("Appearance")]
        public string Text
        {
            get
            {
                if (ViewState["Text"] == null)
                {
                    ViewState["Text"] = "";
                }
                return (string)ViewState["Text"];
            }
            set
            {
                ViewState["Text"] = value;
            }
        }
    }
