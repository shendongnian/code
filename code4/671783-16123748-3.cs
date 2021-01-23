        static void Main(string[] args)
        {
            RUMLib.IObj axObj = new RUMLib.Obj();
            Array a = null;
            axObj.ReadUserMemory(out a, 2, 6);
            for (int i = 0; i < a.Length; ++i)
            {
                Console.Write("{0},", a.GetValue(i));
            }
            Console.WriteLine();
        }
