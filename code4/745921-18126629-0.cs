        public Type Type { get; set; }
        public Object Value { get; set; }
        
        
            if (Type == typeof (int))
            {
                int realValue = (int) Value;
            }
            if (Type == typeof(string))
            {
                string RealValue;
                Buffer.Blockcopy(RealValue, 0, Value, 0, MetadataSizeInValues*sizeof (char));
            }
            if (Type == typeof(float))
            {
                float RealValue = (float) Value;
            }
        
