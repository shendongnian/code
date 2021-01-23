    class MyValue
    {
        public MyValue(bool flag) { Flag = flag; }
        public bool Flag { get; set; }
    }
    class MyValueContainer
    {
        public MyValueContainer(MyValue val) { MyVal = val; }
        public MyValue MyVal { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var someList = new List<MyValueContainer>();
            someList.Add(new MyValueContainer(new MyValue(true)));
            someList.Add(new MyValueContainer(new MyValue(true)));
            someList.Add(new MyValueContainer(new MyValue(false)));
            someList.Add(new MyValueContainer(new MyValue(true)));
            var trueCount = someList.Count(x => x.MyVal.Flag); // 3
            var falseCount = someList.Count(x => !x.MyVal.Flag); // 1
            // try causing side effect by calling Select
            someList.Select(x => x.MyVal.Flag = false);
            // force execution. call Count
            trueCount = someList.Count(x => x.MyVal.Flag); // still 3... no side effect.
            falseCount = someList.Count(x => !x.MyVal.Flag); // still 1... no side effect.
            foreach (var x in someList)
                x.MyVal.Flag = false;
            trueCount = someList.Count(x => x.MyVal.Flag); // 0... side effect seen.
            falseCount = someList.Count(x => !x.MyVal.Flag); // 4...  side effect seen.
        }
    }
