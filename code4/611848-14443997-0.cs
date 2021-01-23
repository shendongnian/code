    public class Stars : ObjectsInTheSky 
    {
        public Stars(int id) : base(id) // base class's constructor passing in the id value
        {
        }
        public StarTypes type;
        public enum StarTypes {Binary,Pulsar,RedGiant}
    }
