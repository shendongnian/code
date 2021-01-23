    <%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
        CodeFile="Default.aspx.cs" Inherits="_Default" %>
    
    <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    
    </asp:Content>
    <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
     <asp:ScriptManager ID="ScriptManager1" runat="server" />
    
    <script type="text/javascript">
        try 
        {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_beginRequest(beginRequest);
    
            function beginRequest() {
                prm._scrollPosition = null;
            }
        }
        catch (err) {
            alert(err);
        }
    </script>
    
    
            <asp:Timer ID="Timer1" Interval="100" runat="server" />
            <asp:UpdatePanel ID="up1" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                </Triggers>
                <ContentTemplate>
                </ContentTemplate>
            </asp:UpdatePanel>
    
    <br /><br />
            <div style="min-height:2000px"></div>
    
            
    </asp:Content>
