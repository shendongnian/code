    C#
       public partial class _Default : System.Web.UI.Page
        {
            public string id = "";
    
            protected void Page_Load(object sender, EventArgs e)
            {
                id = this.Label1.ClientID;
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                string testvalue = this.Label1.Value; 
            }
        }
    //break down at button1_click
    
    
     <asp:HiddenField ID="Label1" runat="server" Value="" /> 
    
    
    javascript 
    
      
    
         $(document).ready(function () {
               
        
                    $("#"+'<%=id%>').val("test");
        
                });
