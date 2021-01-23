    [Serializable]
    public class Variant
    {
        public Variant() { }
        public int variantID { get; set; }
        public string variant_name { get; set; }
    }
    public partial class _Default : System.Web.UI.Page
    {
        public Variant[] Variants
        {
            get
            {
                if (ViewState["Variants"] == null)
                    return new Variant[] { };
                return (Variant[])ViewState["Variants"];
            }
            set { ViewState["Variants"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Variants = new Variant[] { 
                    new Variant() { variantID = 1, variant_name = "T1" },
                    new Variant() { variantID = 2, variant_name = "T2" }
                };
                variantRepeat.DataSource = Variants;
                variantRepeat.DataBind();
            }
        }
        protected void variantRepeat_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Click":
                    var variant = Variants.FirstOrDefault(v => v.variantID.ToString() == e.CommandArgument.ToString());
                    if (variant != null)
                    {
                        txtVariant.Text = variant.variantID.ToString();
                        // show the right view
                    }
                    break;
            }
        }
    }
