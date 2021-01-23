    public object[] Copy(object obj) {
        using (var memoryStream = new MemoryStream()) {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, obj);
            memoryStream.Position = 0;
            return (object[])formatter.Deserialize(memoryStream);
        }
    }
    [Serializable]
    class testobj {
        public string Name { get; set; }
    }
    class Program {
        static object[] list = new object[] { new testobj() { Name = "TEST" } };
        static void Main(string[] args) {
            object[] clonedList = Copy(list);
            (clonedList[0] as testobj).Name = "BLAH";
            Console.WriteLine((list[0] as testobj).Name); // prints "TEST"
            Console.WriteLine((clonedList[0] as testobj).Name); // prints "BLAH"
        }
    }
