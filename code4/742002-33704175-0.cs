    public class MyLabel:Label
    {
        public void PerformClick()
        {
            OnClick(new EventArgs());//InvokeOnClick(this,new EventArgs());
        }
    }
