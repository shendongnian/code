        public interface Iinterface { }
        public class Foo : Iinterface { }
        public class Bar : Iinterface { }
        [TestMethod()]
        public void Test_Concat()
        {
            var bars = new List<Bar>();
            var foos = new List<Foo>();
            var list = foos.Concat<Iinterface>(bars);
        }
