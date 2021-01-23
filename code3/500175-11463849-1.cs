    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace PersonAttributes
    {
        public partial class People : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                repChemicals.ItemCreated += RepChemicalsOnItemCreated;
    
                var chemicals = new[] {"Hydrogen", "Helium", "Lithium", "Beryllium", "Boron"};
    
                if(!IsPostBack)
                {
                    repChemicals.DataSource = chemicals;
                    repChemicals.DataBind();
                }
    
                var dropDownChecklist = "$(document).ready(function () { $('select').dropdownchecklist(); });";
                ScriptManager.RegisterStartupScript(this,GetType(),"initDropDownChecklist",dropDownChecklist,true);
            }
    
            private void RepChemicalsOnItemCreated(object sender, RepeaterItemEventArgs repeaterItemEventArgs)
            {
                var lst = repeaterItemEventArgs.Item.FindControl("lstAttributes") as ListBox;
    
                if (lst == null)
                    return;
    
                lst.DataSource = new[] {"Option 1", "Option 2", "Option 3"};
            }
        }
    }
