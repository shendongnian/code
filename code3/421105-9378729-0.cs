    using System;
    using ProtoBuf.Meta;
    interface ITest
    {
        int X { get; set; }
    }
    abstract class TestBase : ITest
    {
        public int X { get; set; } // from interface
        public int Y { get; set; }
    }
    class Test : TestBase
    {
        public int Z { get; set; }
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", X, Y, Z);
        }
    }
    class Wrapper
    {
        public ITest Value { get; set; }
    }
    public class Program
    {
        static void Main()
        {
            var model = TypeModel.Create();
            model.Add(typeof (ITest), false).Add("X")
                    .AddSubType(10, typeof (TestBase));
            model.Add(typeof (TestBase), false).Add("Y")
                    .AddSubType(10, typeof (Test));
            model.Add(typeof (Test), false).Add("Z");
            model.Add(typeof (Wrapper), false).Add("Value");
            Wrapper obj = new Wrapper {Value = new Test()
                    {X = 123, Y = 456, Z = 789}};
            var clone = (Wrapper)model.DeepClone(obj);
            Console.WriteLine(clone.Value);
        }
    }
