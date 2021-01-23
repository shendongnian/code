    //Id the form tag and place a runat server
      <form id="form1" runat="server" >
    
    //In C# Masterpage.cs - Expose the forms properties
     public System.Web.UI.HtmlControls.HtmlForm Form1 {
                get { return form1; }
                set { form1 = value;
                } }
    //In C# Consuming page add this to pageLoad using UniqueId
     ((SiteMaster)Page.Master).Form1.DefaultButton = btnSearchUsersLink.UniqueID;
