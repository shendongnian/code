    //...
    public class YourEventArgs : EventArgs
    {
       public string Data { get; set; }
    }
    //...
    public event EventHandler DataReceived = null;
    ...
    protected override OnDataReceived(object sender, YourEventArgs e)
    {
       if(DataReceived != null)
       {
          DataReceived(this, new YourEventArgs { Data = "data to pass" });
       }
    }
