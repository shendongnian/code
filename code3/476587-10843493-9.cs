    byte[] ToByteArray(newLeads value)
    {
        Encoding encoding = new ASCIIEncoding(); //Choose some encoding
        byte[] id = EncodeString(value.id, encoding);
        byte[] first_name = EncodeString(value.first_name, encoding);
        byte[] last_name = EncodeString(value.last_name, encoding);
        byte[] result = new byte[id.Length + first_name.Length + last_name.Length];
        System.Buffer.BlockCopy(id, 0, result, 0, id.Length);
        System.Buffer.BlockCopy(first_name, 0, result, id.Length, first_name.Length);
        System.Buffer.BlockCopy(last_name, 0, result, id.Length + first_name.Length, last_name.Length);
        return result;
    }
    byte[] EncodeString(string str, Encoding encoding)
    {
        byte[] data;
        byte[] data_length;
        Union union = new Union();
        if (ReferenceEquals(str, null))
        {
            data = new byte[0];
            union.data = -1;
        }
        else
        {
            data = encoding.GetBytes(str);
            union.data = str.Length;
        }
        data_length = new byte[]{union.a, union.b, union.c, union.c};
        int length = data.Length;
        byte[] result = new byte[4 + data.Length];
        System.Buffer.BlockCopy(data_length, 0, result, 0, 4);
        System.Buffer.BlockCopy(data, 0, result, 4, length);
        return result;
    }
    //I hope endianess doesn't bite
    [StructLayout(LayoutKind.Explicit)] 
    struct Union
    {
        [FieldOffset(0)]
        public int data;
        [FieldOffset(0)] 
        public byte a;
        [FieldOffset(1)] 
        public byte b;
        [FieldOffset(2)] 
        public byte c;
        [FieldOffset(3)] 
        public byte d;
    }
