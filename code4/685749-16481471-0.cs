    //Base class
    using System.Windows.Controls;
    namespace Controls
    {
        public class BaseUserControl: UserControl
        {
            protected string getText()
            {
                return "Hello World";
            }
        }
    } 
    
    //Sub class
    <Controls:BaseUserControl x:Class="MyNameSpace.MyUserControl"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:Controls="clr-namespace:Controls;assembly=MyAssembly">
    </Controls:BaseUserControl>
    using Controls;
    public partial class MyUserControl : BaseUserControl
    {
        public MyUserControl ()
        {
            var baseText = getText();
        }
    }
