     //IN web user control aspx page add a place holder in which u add your dynamic    controls
     <%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs"   Inherits="WebUserControl" %>
      <asp:PlaceHolder runat="server"  ID="mycontrol"/>
      // WEb User Control Code Behind 
      // Create public properties
       public int totalnoOfcontrols
       {
        get;
        set;
       }
     protected void Page_Load(object sender, EventArgs e)
     {
        if (IsPostBack)
        { 
            // save values here 
        }
     }
     protected void Page_Init(object sender, EventArgs e)
     { 
        // create dynamic controls here
         TextBox t = new TextBox();
        t.Text = "";
        t.ID = "myTxt";
        mycontrol.Controls.Add(t);
     }
