    [StructLayout(LayoutKind.Sequential)]
    public struct MyManagedStruct_Foo
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
        public byte[] product_name;
    
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
        public byte[] product_model;
    
        public string GetProductName()
        {
            return System.Text.Encoding.ASCII.GetString(this.product_name);
        }
    
        public string GetProductModel()
        {
            return System.Text.Encoding.ASCII.GetString(this.product_model);
        }
    }
