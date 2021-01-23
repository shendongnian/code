    House house = new House()
    {
        Size = new Size()
        {
            Width = 10
        }
    };
    House house2 = new House()
    {
         Size = new Size()
         {
            Width = 20
         }
    };
    House equal = new House()
    {
        Size = new Size()
        {
            Width = 10
        }
    };
    Debug.Assert(UnsafeCompare(ObjectToByteArray(house), ObjectToByteArray(equal)));
    Debug.Assert(!UnsafeCompare(ObjectToByteArray(house), ObjectToByteArray(house2)));
    Debug.Assert(ByteArrayCompare(ObjectToByteArray(house), ObjectToByteArray(equal)));
    Debug.Assert(!ByteArrayCompare(ObjectToByteArray(house), ObjectToByteArray(house2)));
