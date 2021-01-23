    static void Main(string[] args)
        {
            testclass test = new testclass();
            IFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(new byte[512],0,512,true,true);
            bf.Serialize(ms,test);
            ms.Seek(0,SeekOrigin.Begin); //rewinded the stream to the begining.
            testclass detest=(testclass)bf.Deserialize(ms);
            Console.ReadLine();
        }
