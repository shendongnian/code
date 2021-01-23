    public partial class TestRJF2 : System.Web.UI.Page
    {
        private IList<TextBox> AddedControls = new List<TextBox>();
        protected override void CreateChildControls()
        {
            BuildControls();
            base.CreateChildControls();
        }
    
        private void BuildControls()
        {
            for (var x = 0; x < TotalNumberAdded; x++)
            {
                var id = String.Format("NatureTextBox{0}", x);
                //Check if control was already added 
                //only create controls that are new for this postback
                if (AccidentPlaceHolder.FindControl(id) == null)
                {
                    var textBox = new TextBox() {ID = id};
                    AccidentPlaceHolder.Controls.Add(textBox);
                    AddedControls.Add(textBox);
                }
            }
        }
    
        protected override void OnPreRender(EventArgs e)
        {
            foreach (var ctrl in AddedControls)
            {
                var key = ctrl.ID.Replace("TextBox", String.Empty);
                Session[key] = ctrl.Text;
            }
    
            foreach (string session in Session.Keys)
            {
                System.Diagnostics.Debug.WriteLine(String.Format("{0} = {1}", session, Session[session]));
            }
            base.OnPreRender(e);
        }
    
        protected void AccidentButton_Click(object sender, EventArgs e)
        {
            TotalNumberAdded++;
            BuildControls();
        } 
        protected int TotalNumberAdded
        {
            get { return (int)(ViewState["TotalNumberAdded"] ?? 0); }
            set { ViewState["TotalNumberAdded"] = value; }
        } 
    }
