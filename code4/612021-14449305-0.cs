    <%@ Control Language="C#" AutoEventWireup="true" 
        CodeBehind="ucRequests.ascx.cs"
        Inherits="RepeaterWebApplication.ucRequests" %>
    <asp:Button runat="server" ID="btnAdd" CssClass="btn" Text="Add" 
       OnClick="btnAdd_Click" />
    <br /><asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>
    
    <%@ Control Language="C#" AutoEventWireup="true" 
       CodeBehind="ucRequest.ascx.cs" 
       Inherits="RepeaterWebApplication.ucRequest" %>
    <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
    
    private List<int> _controlIds;
    
    private List<int> ControlIds
    {
        get
        {
            if (_controlIds == null)
            {
                if (ViewState["ControlIds"] != null)
                    _controlIds = (List<int>) ViewState["ControlIds"];
                else
                    _controlIds = new List<int>();
            }
            return _controlIds;
        }
        set { ViewState["ControlIds"] = value; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            foreach (int id in ControlIds)
            {
                Control ctrl = Page.LoadControl("ucRequest.ascx");
                ctrl.ID = id.ToString();
    
                PlaceHolder1.Controls.Add(ctrl);
            }
        }
    }
    
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var reqs = ControlIds;
        int id = ControlIds.Count + 1;
    
        reqs.Add(id);
        ControlIds = reqs;
    
        Control ctrl = Page.LoadControl("ucRequest.ascx");
        ctrl.ID = id.ToString();
    
        PlaceHolder1.Controls.Add(ctrl);
    }
