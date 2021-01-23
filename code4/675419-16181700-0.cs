    using System;
    using System.Collections;
    using System.Web.UI.WebControls;
    
    public partial class TestCode_General_ResharperTest : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Page.IsPostBack)
                return;
            
            var testList = new DropDownList();
            testList.DataSource = GetTestListData();
            testList.DataValueField = "ID";
            testList.DataTextField = "Name";
            testList.DataBind();    /* Databind causes the public variables to be accessed.*/
        }
    
        private static IEnumerable<object> GetTestListData()
        {
            var groups = new List<object>();
            var pairs = new[] { "Test:1", "Test 2:2", "Test 3:3" };
            foreach (var pair in pairs)
            {
                var values = pair.Split(new[] { ':' });
                groups.Add(new { ID = values[0], Name = values[1] });
            }
            return groups;
        }
    }
