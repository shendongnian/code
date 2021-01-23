    public class StackOverflow_10543252
    {
        public static void Test()
        {
            byte[] bytes = Enumerable.Range(0, 256).Select(i => (byte)i).ToArray();
            File.WriteAllBytes("a.bin", bytes);
            FileStream fs1 = File.OpenRead("a.bin");
            fs1.Seek(40, SeekOrigin.Begin);
            FileStream fs2 = File.OpenRead("a.bin");
            fs2.Seek(120, SeekOrigin.Begin);
            Console.WriteLine(fs1.ReadByte()); // should be 40
            Console.WriteLine(fs2.ReadByte()); // should be 120
            fs1.Close();
            fs2.Close();
            File.Delete("a.bin");
        }
    }
