    if you want to pass data to user (FindControl because added dynamicly)
        
        you must use this
        
        public partial class UserControl1 : System.Web.UI.UserControl
        {
            public string Property
            {
                get { return dd.SelectedValue; }
                set { dd.SelectedValue = value; }
            }
        }
        
        
        When you create, affect UniqueId to your user control
        
        UserControl1 control = new UserControl1();
        control.UniqueId="Test";  
        add.....
        
        And find it in your page  with PreInit event before other events 
        
        UserControl1 control = (UserControl1)Page.FindControl("Test");
        control.Property = your value;
    
    
    
    But if you want to pass data to your user control, this last must have this property with public modifier.
    You can also pass with static forms as this example
    
    <tagprefix:tagname id="" runat="server" Property="your value"/>
