    public class Cat : BaseMammal
    {
        public void Feed()
        {
            Trace.Write("cat feeding");
            BePicky();//some custom cat like functionality
            base.Feed(); //and afterwards its still just a mammal after all
        }
    }
    public class Gruffalo : BaseMammal
    {
        public void Feed()
        {
            Trace.Write("Gruffalo feeding");
            WeirdWayOfEating();//the base implementation is not appropriate
        }
    }
