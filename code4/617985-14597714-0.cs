    <%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
        CodeFile="About.aspx.cs" Inherits="About" %>
    
    <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
    <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <div>
            <asp:ScriptManager ID="scrManager" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="updPnl" runat="server" >
               
                <ContentTemplate>
                    <asp:GridView ID="grdNumber" runat="server">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNumber" runat="server" OnTextChanged="TextBox1_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlNumber" runat="server" OnSelectedIndexChanged="ddlNumber_SelectedIndexChanged"
                                        AutoPostBack="true">
                                        <asp:ListItem>One</asp:ListItem>
                                        <asp:ListItem>Two</asp:ListItem>
                                        <asp:ListItem>Three</asp:ListItem>
                                        <asp:ListItem>For</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Content>
----------------------
---------------------------------
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Rows.Add();
                dt.Rows.Add();
                dt.Rows.Add();
                dt.Rows.Add();
    
                grdNumber.DataSource = dt;
                grdNumber.DataBind();
            }
        }
    
        protected void ddlNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }
    
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            var value = (sender as TextBox).Text;
        }
    }
