    public class MyEventArgs : EventArgs
    {
       public string MyEventString {get; set; }
       public MyEventArgs(string myString)
       {
           this.MyEventString = myString;
       }
    }
