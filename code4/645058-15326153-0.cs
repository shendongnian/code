    public partial class _default : System.Web.UI.Page
    {
        public List<LabelInfo> LabelInfos
        {
            get
            {
                object listOfLabelInfos = ViewState["Labels"];
                return (listOfLabelInfos == null) ? null : (List<LabelInfo>)listOfLabelInfos;
            }
            set
            {
                ViewState["Labels"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // Init the LabelInfo list, if this page load is not a postback.
            if (!IsPostBack)
            {
                LabelInfos = new List<LabelInfo>();
            }
        }
        protected void btnTest_Click(object sender, EventArgs e)
        {
            LabelInfos.Add(new LabelInfo { Text = "TestLabel", CssClass = "TestClass" });
            foreach (LabelInfo l in LabelInfos)
            {
                this.in_mess.Controls.Add(new Label { Text = l.Text, CssClass = l.CssClass });
            }
        }
    }
    [Serializable]
    public class LabelInfo
    {
        public string Text = "";
        public string CssClass = "";
    }
