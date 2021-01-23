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
                    OnSendMessage("I'm sending a message"); // i don't know and i don't care where it will go
                }
            }
    
            public event SendMessageDelegate OnSendMessage; // anyone can subscribe to this event
        }
        
        public delegate void SendMessageDelegate(string message); // what is the event handler method supposed to look like? 
        // it's supposed to return nothing (void) and to accept one string argument
    }
Window1.xaml
    <Window x:Class="WpfApplication1.Window1"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Window1" Height="300" Width="300">
        <Grid>
            <TextBox Name="tbMessage" /> <!-- just a textbox -->
        </Grid>
    </Window>
