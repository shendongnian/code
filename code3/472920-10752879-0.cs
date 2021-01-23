MyClass.cs
    namespace WpfApplication1
    {
        // this class does not know anything about the window directly
        public class MyClass
        {
            public void DoSomething()
            {
                if (OnSendMessage != null) // is anybody listening?
                {
                    OnSendMessage("I'm sending a message");
                }
            }
    
            public event SendMessageDelegate OnSendMessage; // anyone can subscribe to this event
        }
        
        public delegate void SendMessageDelegate(string message);
    }
Window1.xaml
    <Window x:Class="WpfApplication1.Window1"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Window1" Height="300" Width="300">
        <Grid>
            <TextBox Name="tbMessage" />
        </Grid>
    </Window>
