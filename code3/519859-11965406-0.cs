    class SomeDataClass {
        public SomeData Data {get;set;}
    }
    class SomeData {
        static SomeData Load(string path) {
            return new SomeData(); // TODO
        }
        public static implicit operator SomeData(string path)
        {
            return Load(path);
        }
    }
    static class Program {
        static void Main()
        {
            SomeDataClass data1 = new SomeDataClass();
            SomeDataClass data2 = new SomeDataClass();
    
            data1.Data = "somefile.dat"; // this is a load
            data2.Data = data1.Data; // this is not a load
        }
    }
