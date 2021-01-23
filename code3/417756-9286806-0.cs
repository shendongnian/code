    class MyArray<T>
    {
        private T[,,] array;
        public MyArray(int xSize, int ySize, int zSize)
        {
            array = new T[xSize,ySize,zSize];
        }
        public T this[XYZ xyz]
        {
            get { return array[xyz.x, xyz.y, xyz.z]; }
            set { array[xyz.x, xyz.y, xyz.z] = value; }
        }
    }
