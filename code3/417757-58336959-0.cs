    class MyArray<T>
    {
        private T[,,] array;
    
        // Constructor
        public MyArray(int xSize, int ySize, int zSize)
        {
            array = new T[xSize,ySize,zSize];
        }
    
        // Index with your own struct XYZ
        public T this[XYZ xyz]
        {
            get { return array[xyz.x, xyz.y, xyz.z]; }
            set { array[xyz.x, xyz.y, xyz.z] = value; }
        }
        
        // Normal index
        public T this[int x, int y , int z]
        {
            get { return array[x, y, z]; }
            set { array[x, y, z] = value; }
        }
    
        // Get dimensions
        public int GetLength(int dim)
        {
            return array.GetLength(dim);
        }
    }
