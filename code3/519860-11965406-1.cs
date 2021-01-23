    class SomeDataClass {
        public SomeData Data {get;set;}
    }
    class SomeData {
        public static SomeData Load(string path) {
            return new SomeData(); // TODO
        }
    }
    static class Program {
        static void Main()
        {
            SomeDataClass data1 = new SomeDataClass();
            SomeDataClass data2 = new SomeDataClass();
    
            data1.Data = SomeData.Load("somefile.dat");
            data2.Data = data1.Data;
        }
    }
