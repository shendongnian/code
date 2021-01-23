    public class SoAndSo<DerivedT> : IUnknown<DerivedT>
    {
        public void PrintName<T>(T someT) { Console.WriteLine("PrintName<T>(T someT)"); }
        void IUnknown<DerivedT>.PrintName(DerivedT derivedT) { Console.WriteLine("PrintName(DerivedT derivedT)"); }
    }
    public class Test
    {
        public static void TestIt()
        {
            List<IUnknown> unknowns = new List<IUnknown>();
            unknowns.Add(new SoAndSo<int>());
            unknowns.Add(new SoAndSo<string>());
            //*** statement below should print "PrintName(DerivedT derivedT)"
            (unknowns[0] as IUnknown<int>).PrintName(10);
            //*** statement below should print "PrintName<T>(T someT)"
            unknowns[0].PrintName("abc");
        }
    }
