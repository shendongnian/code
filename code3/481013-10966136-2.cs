    public class CloneInfo  
    {  
        public float Mass;  
    }  
    public class Clone  
    {  
        private CloneInfo _info;  
        public float Mass { get { return _info.Mass; } }  
        public Clone(CloneInfo info)  
        {  
            _info = info;
        }  
    }  
