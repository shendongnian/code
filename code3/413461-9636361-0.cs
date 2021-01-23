    <%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
        CodeBehind="Default.aspx.cs" Inherits="TheAnswer._Default" %>
    
    <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
    <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <br />
        <script type="text/javascript">
            function ClientCallbackFunction(args) {
                var labelMessage = $get("<%= LabelMessage.ClientID %>");
                if (labelMessage) {
                    labelMessage.innerText = args;
                }
            }
            function MyServerCallWrapper() {
                var dropDown = $get("<%= DropDownListChoice.ClientID %>");
                if (dropDown) {
                    MyServerCall(dropDown.value);
                }
            }
        </script>
    </asp:Content>
    <asp:Content ID="Content1" runat="server" ContentPlaceHolderID="FooterContent">
        <asp:DropDownList ID="DropDownListChoice" runat="server" onchange="javascript:MyServerCallWrapper();">
            <asp:ListItem>Choice 1</asp:ListItem>
            <asp:ListItem>Choice 2</asp:ListItem>
            <asp:ListItem>Choice 3</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="LabelMessage" runat="server"></asp:Label>
    </asp:Content>
