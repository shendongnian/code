    <%@ Master Language="C#" MasterPageFile="~/umbraco/masterpages/default.master" AutoEventWireup="true" %>    
    
    <%@ Import Namespace="umbraco.NodeFactory" %>
      
    <script runat="server" language="CSharp">
        protected void Page_Load(object sender, EventArgs e)
        {
            // prevents template to be run without proper authorisation
            Node currentNode = Node.GetCurrent();
            Node currentHome = new Node(int.Parse(currentNode.Path.Split(',')[1]));
            Boolean HasAccess = umbraco.library.HasAccess(currentNode.Id, currentNode.Path);
            Boolean IsProtected = umbraco.library.IsProtected(currentNode.Id, currentNode.Path);
				    		
            if (IsProtected && !HasAccess)
            {
                // redirect to ancestor-or-self::HomePage
    		Response.Status = "403 Forbidden";
	    	Response.Redirect(umbraco.library.NiceUrl(currentHome.Id), true);
            }
        }
    </script>      
      
    <asp:Content ContentPlaceHolderID="ContentPlaceHolderDefault" runat="server">
        <!-- redirect to parent story -->
    </asp:Content> 
