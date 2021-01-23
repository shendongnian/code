    public partial class LinkedDropDownsBound : System.Web.UI.Page
    {
        public Dictionary<String, Boolean> FromYears
        {
            get
            {
                if (ViewState["FromYears"] == null)
                {
                    ViewState["FromYears"] = new Dictionary<String, Boolean>();
                }
                return ViewState["FromYears"] as Dictionary<String, Boolean>;
            }
            set
            {
                ViewState["FromYears"] = value;
            }
        }
        public Dictionary<String, Boolean> ToYears
        {
            get
            {
                if (ViewState["ToYears"] == null)
                {
                    ViewState["ToYears"] = new Dictionary<String, Boolean>();
                }
                return ViewState["ToYears"] as Dictionary<String, Boolean>;
            }
            set
            {
                ViewState["ToYears"] = value;
            }
        }
        public int MinYear = 1975;
        public int MaxYear = 2015;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitFromYears();
                InitToYears();
                DataBind();
            }
        }
        private void InitFromYears()
        {
            FromYears = new Dictionary<string, bool>();
            IEnumerable<int> fromRange = Enumerable.Range(MinYear, MaxYear - MinYear);
            foreach (var fromYear in fromRange)
            {
                FromYears.Add(fromYear.ToString(), fromYear == (DateTime.Now.Year - 2));
            }
        }
        private void InitToYears()
        {
            ToYears = new Dictionary<string, bool>();
            //get the selected FromYear Value
            int minToYear = Convert.ToInt32(FromYears.FirstOrDefault(dict => dict.Value).Key);
            //make sure ToYears is at least FromYears
            if (minToYear < Convert.ToInt32(FromYears.Min(k => k.Key)))
            {
                minToYear = Convert.ToInt32(FromYears.Min(k => k.Key));
            }
            IEnumerable<int> toRange = Enumerable.Range(minToYear, MaxYear - minToYear);
            foreach (var toYear in toRange)
            {
                ToYears.Add(toYear.ToString(), toYear == (DateTime.Now.Year + 2));
            }
        }
        protected void DDLFromDataBind(object sender, EventArgs e)
        {
            FromYearsDDL.DataSource = FromYears;
            FromYearsDDL.DataValueField = "Key";
            FromYearsDDL.DataTextField = "Key";
            FromYearsDDL.SelectedValue = FromYears.FirstOrDefault(y => y.Value).Key;
        }
        protected void DDLFromSelectedIndexChanged(object sender, EventArgs e)
        {
            //update the FromYear Dictionary
            var tempDictionary = FromYears.ToDictionary(fromYear => fromYear.Key, fromYear => fromYear.Key.Equals(FromYearsDDL.SelectedValue));
            FromYears = tempDictionary;
            //Call Bind on the ToYear DDL
            ToYearsDDL.DataBind();
            //do my other update stuff here
            FromLabel.Text = FromYearsDDL.SelectedValue;
            ToLabel.Text = ToYearsDDL.SelectedValue;
        }
        protected void DDLToSelectedIndexChanged(object sender, EventArgs e)
        {
            //do my other update stuff here
            FromLabel.Text = FromYearsDDL.SelectedValue;
            ToLabel.Text = ToYearsDDL.SelectedValue;
        }
        protected void DDLToDataBind(object sender, EventArgs e)
        {
            InitToYears();
            ToYearsDDL.DataSource = ToYears;
            ToYearsDDL.DataValueField = "Key";
            ToYearsDDL.DataTextField = "Key";
            ToYearsDDL.SelectedValue = ToYears.FirstOrDefault(y => y.Value).Key;
        }
    }
