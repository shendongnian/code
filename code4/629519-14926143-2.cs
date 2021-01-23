    public class SensorInput
    {
        public SensorInput(bool a, bool b, bool c)
        {
            A = a;
            B = b;
            C = c;
        }
    
        public bool A { get; private set; }
        public bool B { get; private set; }
        public bool C { get; private set; }
        public bool Output
        {
            // output logic goes here
            get { return A || B || C; }
        }
    }
