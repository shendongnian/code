        static void Main(string[] args)
        {
            string filepath = @"C:\FileLocation\";
            string filename = "datasaved.bin";
            MyClass something = new MyClass();
            // serialize
            using ( FileStream strm = File.OpenWrite(Path.Combine(filepath, filename)))
            {
                BinaryFormatter ser = new BinaryFormatter();
                ser.Serialize(strm, something);
            }
            // deserialize
            using (FileStream strm = File.OpenRead(Path.Combine(filepath, filename)))
            {
                BinaryFormatter ser = new BinaryFormatter();
                something = ser.Deserialize(strm) as MyClass;
            }
        }
