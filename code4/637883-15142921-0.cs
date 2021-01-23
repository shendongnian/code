    [ToolboxData("<{0}:ServerControl1 runat=server></{0}:ServerControl1>")]
    [DefaultProperty("StartYear")]
    public class YearDropDownList : DropDownList
    {
        public string StartYear
        {
            get
            {
                String s = (String)ViewState["StartYear"];
                return ((s == null) ? "2009" : s);
            }
            set
            {
                ViewState["StartYear"] = value;
                RegenerateList();
            }
        }
        // Defer regenerating the list until as late as possible    
        protected void OnPreRender(EventArgs e)
        {
            RegenerateList();
            base.OnPreRender(e);
        }
        public void RegenerateList()
        {
            // Remove any existing items.
            this.Items.Clear();
            for (int i = Int32.Parse(StartYear); i <= DateTime.Now.Year; i++)
            {
                this.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
    }
