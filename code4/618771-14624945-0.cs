    public class PositionChangedEventArgs : EventArgs
    {
       public bool Cancel {get;set;}
       public int NewValue {get;set;}
      
    } 
    public event EventHandler<PositionChangedEventArgs> PositionChanged {get;set;}
    protected virtual void OnPositionChanged(int newValue)
    {
        if (this.PositionChanged !=null)
        {
            var args = new PositionChangedEventArgs(){NewValue = newValue};
            this.PositionChanged(this,args);
            if (args.Cancel)
            {
                //Do something to cancel..
            }
        }
    }
