    public DataPool<T>
    {
            internal class DataStructHelper<T>
            {
                public T DataObject { get; private set; }
                public int Size { get; private set; }
                public DataStructHelper(T dataObject)
                {
                    DataObject = dataObject;
                    Size = GetObjectSize(dataObject);
                }
    
                private int GetObjectSize(T TestObject)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (MemoryStream ms = new MemoryStream())
                    {
                        byte[] Array;
                        bf.Serialize(ms, TestObject);
                        return ms.ToArray().Length;
                    }
                }
            }
        }
    // Other code here
    }
