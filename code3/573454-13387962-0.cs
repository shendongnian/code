    public partial class ABCQuestionSingle : System.Web.UI.UserControl
    {
        public void LoadDropDown<T>(string valueProperty, string textProperty)
            where T : class
        {
            ddlResponse.DataTextField = textProperty;
            ddlResponse.DataValueField = valueProperty;
            ddlResponse.DataSource = new CareDAL.ABC.Entities().Set<T>();
            ddlResponse.DataBind();
        }
    }
