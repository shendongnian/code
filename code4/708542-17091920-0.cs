    public static void StringArrayToPtr(IntPtr ptr, string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            byte[] chars = System.Text.Encoding.ASCII.GetBytes(array[i] + '\0');
            Marshal.Copy(chars, 0, IntPtr.Add(ptr, 128 * i), chars.Length);
        }
    }
