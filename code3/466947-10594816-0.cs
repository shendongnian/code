    public class StackOverflow_10594371
    {
        public static void Test()
        {
            using (FileStream fs = File.Create("a.bin"))
            {
                fs.WriteByte(0xFF);
                fs.WriteByte(0xFE);
                fs.WriteByte(0x41);
                fs.WriteByte(0x00);
                fs.WriteByte(0x42);
                fs.WriteByte(0x00);
                fs.WriteByte(0x43);
                fs.WriteByte(0x00);
            }
            Console.WriteLine(File.ReadAllText("a.bin"));
        }
    }
