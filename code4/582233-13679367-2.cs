        //dummy class replacing the service object and it's methods
        public class MyServiceObject
        {
            public void ServiceMethod1(SubSubC param)
            { }
            public void ServiceMethod2(SubSubE param)
            { }
        }
        public class BaseA
        {
            public int CustomerId { get; set; }
            public string UniqueName { get; set; }
        }
        public class SubB : BaseA
        {
        }
        public class SubSubC : SubB
        {
            public SubSubC(BaseA baseA)
            {
                this.CustomerId = baseA.CustomerId;
                this.UniqueName = baseA.UniqueName;
            }
        }
        public class SubD : BaseA
        {
        }
        public class SubSubE : SubD
        {
            public SubSubE(BaseA baseA)
            {
                this.CustomerId = baseA.CustomerId;
                this.UniqueName = baseA.UniqueName;
            }
        }
        public class MyMain
        {
            //declare the SubSub objects
            //SubSubC subSubC;
            //SubSubE subSubE;
            BaseA baseA;
            public MyMain()
            {
                //assign the values to each class in the MyMain contrsuctor
                baseA = new BaseA { CustomerId = 2, UniqueName = "XXBB" };
                //subSubC = new SubSubC() { CustomerId = 2, UniqueName = "XXBB" };
                //subSubE = new SubSubE() { CustomerId = 3, UniqueName = "ZZCC" };
            }
            //call the methods passing in the class scoped objects
            public void SendRequestToService1()
            {
                (new MyServiceObject()).ServiceMethod1(new SubSubC(baseA));
            }
            public void SendRequestToService2()
            {
                (new MyServiceObject()).ServiceMethod2(new SubSubE(baseA));
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                MyMain myMain = new MyMain();
                myMain.SendRequestToService1();
                myMain.SendRequestToService2();
            }
        }
