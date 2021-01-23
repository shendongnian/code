    public class Vector
    {
        protected double[] Values;
        public int Length { get { return Values.Length; } }
    
        public static Vector operator +(Vector v1, Vector v2)
        {
            if (v1.Length != v2.Length)
            {
                throw new VectorTypeException("Vector Dimensions Must Be Equal");
            }
            else
            {
                //perform generic matrix addition/operation
                double[] newValues = new double[v1.Length];
                for (int i = 0; i < v1.Length; i++)
                {
                    newValues[i] = v1.Values[i] + v2.Values[i];
                }
    
                //or use some factory/service to give you a Vector2D, Vector3D, or VectorND
                return new Vector() { Values = newValues };
            }
        }
    }
    
    public class Vector2D : Vector
    {
        public double X
        {
            get { return Values[0]; }
            set { Values[0] = value; }
        }
        public double Y
        {
            get { return Values[1]; }
            set { Values[1] = value; }
        }
    }
    
    
    public class Vector3D : Vector
    {
        public double X
        {
            get { return Values[0]; }
            set { Values[0] = value; }
        }
        public double Y
        {
            get { return Values[1]; }
            set { Values[1] = value; }
        }
        public double Z
        {
            get { return Values[2]; }
            set { Values[2] = value; }
        }
    }
