    public class Outputs
    {
        private float[] _values;
    
        public float this[int index]
        {
            get { return _values[index]; }
            set
            {            
                if (float.IsNaN(value))
                    throw new Exception("Blar blar");
                _values[index] = value;
            }
        }
    }
    public class Container
    {
        public Outputs Outputs { get; set; }
    }
    ...
    var container = new Container();
    container.Outputs[0] = 2.5f;
    container.Outputs[1] = 0.4f;
    ...
    
