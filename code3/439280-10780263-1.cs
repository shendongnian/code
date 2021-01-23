    using System.Runtime.InteropServices;   
`
    public Int16[] Copy_Byte_Buffer_To_Int16_Buffer(byte[] buffer)
    {
        Int16[] result = new Int16[1];
        int size = buffer.Length;
        if ((size % 2) != 0)
        {
            /* Error here */
            return result;
        }
        else
        {
            result = new Int16[size/2];
            IntPtr ptr_src = Marshal.AllocHGlobal (size);
            Marshal.Copy (buffer, 0, ptr_src, size);
            Marshal.Copy (ptr_src, result, 0, result.Length);
            Marshal.FreeHGlobal (ptr_src);
            return result;
        }
    }`
    
    
