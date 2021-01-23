    public class Stars : ObjectsInTheSky 
    {
        public Stars(int id) : base(id) // base class's constructor passing in the id value
        {
        }
        public Stars()  // in order to not break the code above
        {
        }
        public StarTypes type;
        public enum StarTypes {Binary,Pulsar,RedGiant}
    }
