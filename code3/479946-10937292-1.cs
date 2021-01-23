    using System.Web.Script.Serialization;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack && ScriptManager.GetCurrent(this).IsInAsyncPostBack)
        {
            string nName = Request.Form["name"];
            // do validation and storage of accepted value
            // prepare your result object with values 
            
            result.code = some code for status on the other side
            result.message = 'Some descriptive message to be shown on the page';
            // return json result
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Response.Write(serializer.Serialize(result));
        }
    }
