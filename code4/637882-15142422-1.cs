    [ToolboxData("<{0}:YearDropDownList runat=\"server\" StartYear=\"[StartYear]\"></{0}:YearDropDownList>")]
    [DefaultProperty("StartYear")]
    public class YearDropDownList : DropDownList
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            RegenerateList();
        }
        public string StartYear
        {
            get
            {
                String s = (String)this.ViewState["StartYear"];
                return s ?? "2009";
            }
            set
            {
                ViewState["StartYear"] = value;
                RegenerateList();
            }
        }
        public void RegenerateList()
        {
            Items.Clear();
            for (int i = Int32.Parse(this.StartYear); i <= DateTime.Now.Year; i++)
            {
                this.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
    }
