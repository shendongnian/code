     <input type="hidden" id="ListCount" runat="server" value="0" />
    public partial class Pages_Application_Application : System.Web.UI.Page
    {
    protected List<IdValue> ProposersList
    {
        get
        {
            if (ViewState["proposersList"] == null)
                ViewState["proposersList"] = new List<IdValue>();
            return ViewState["proposersList"] as List<IdValue>;
        }
        set
        {
            ViewState["proposersList"] = value;
            ListCount=value; 
        }
    }
    public int ListCount
    {
        get
        {
            return this.ProposersList.Count;
        }
    }
    <script type="text/javascript">
    function CustomValidator2_ClientValidate(source, arguments) {
        var count= document.getElementById("ListCount").value;
        alert(count);
        arguments.IsValid = count > 0;
    }
