    public class BuyTourProduct : UserControl
    {
        // ...
        public delegate void MyHideEventDelegate();
        public event MyHideEventDelegate MyHideEvent;
        // ...
        public void SomeFunction()
        {
            if (MyHideEvent != null)
                MyHideEvent();
        }
        // ... 
    }
