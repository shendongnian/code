    public class Scroller
    {
        public Scroller(ISCrollable scrollable)
        {
            //attach behaviour
            scrollable.Bar.OnClick += DoScroll;
            //and other stuff
        }
    }
