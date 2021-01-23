    public class MyEventArgs : EventArgs
    {
        public object Changer;
    }
    public void SetProperty(string p_newValue, object p_changer)
    {
       MyEventArgs eventArgs = new MyEventArgs { Changer = p_changer };
       PropertyChanged(this, eventArgs); 
    }
