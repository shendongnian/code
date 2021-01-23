    [ToolboxData("<{0}:ServerControl1 runat=server></{0}:ServerControl1>")]
    [DefaultProperty("StartYear")]
    public class YearDropDownList : DropDownList
    {
        public YearDropDownList()
        {
            RegenerateList();
        }
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
        public void RegenerateList()
        {
            for (int i = Int32.Parse(StartYear); i <= DateTime.Now.Year; i++)
            {
                this.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
    }
