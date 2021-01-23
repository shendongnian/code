    public class Stars : ObjectsInTheSky 
    {
        public Stars(int id) : base(id) { }
    
        public StarTypes type;
        public enum StarTypes {Binary,Pulsar,RedGiant}
    }
