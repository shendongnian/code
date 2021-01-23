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
            }
            public void SendRequestToService1()
            {
                var subSub=new SubSubC();
                (new MyServiceObject()).ServiceMethod1(Initialize(ref subSub));
            }
            public void SendRequestToService2()
            {
                var subSub = new SubSubE();
                (new MyServiceObject()).ServiceMethod2(Initialize(ref subSub));
            }
            private T Initialize<T>(ref T subSub) where T:BaseA
            {
                subSub.CustomerId = baseA.CustomerId;
                subSub.UniqueName = baseA.UniqueName;
                return subSub;
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
