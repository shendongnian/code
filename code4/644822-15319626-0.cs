       static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        static byte[] Big2Little(byte[] data)
        {
            for (int i = 0; i < data.Length / 2; i++)
            {
                Swap<byte>(ref data[i], ref data[data.Length - i - 1]);
            }
            return data;
        }
        static void Main(string[] args)
        {
            byte[] bytes = BitConverter.GetBytes(0x42E65600);
            if (!BitConverter.IsLittleEndian)
            {
                bytes = Big2Little(bytes);
            }
            float myFloat = BitConverter.ToSingle(bytes, 0);
            System.Console.Out.WriteLine(myFloat);
        }
