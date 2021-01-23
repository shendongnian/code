    public class BasePage : System.Web.UI.Page
    {
        protected virtual DropDownList MyDropDown { get; set; }
        protected void PopulateList()
        {
            if (MyDropDown != null)
                MyDropDown.Items.Add("option");
        }
    }
    public partial class MyPage : BasePage
    {
        protected override DropDownList MyDropDown
        {
            get
            {
                return DerivedClassList;
            }
            set
            {
                base.DerivedClassList = value;
            }
        }
    }
