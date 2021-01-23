    1. In the user control, create a public string property that returns textbox string value..
    
    public string MyText
    {
    get
    {
    return txt1.Text;
    }
    }
    
    2. Register the user control on the page
    
    <%@ Register TagPrefix="uc" TagName="MyControl" Src="~/mycontrol.ascx" />
    
    and declare it..
    
    <uc:MyControl ID="control1" runat="server" />
    
    3. From the codebehind now you can read the property..
    
    Response.Write(control1.MyText);
    
    Hope it helps
    
    Thanks...
