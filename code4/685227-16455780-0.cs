    public class Foo
    {
        private int index = 0;
        private string[] arr = new [] { "Hello and Welcome",
                                        "To the new app",
                                        "enjoy your stay",
                                        "press next to continue" };     
        
        private void ButtonCallback(...)
        { 
             tbArray.Text = arr[index++]; 
        }
    }
