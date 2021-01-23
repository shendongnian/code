    public class MyInfoService : ServiceBase<MyReuest>
    {
        protected override object Run(MyReuest request)
        {
           Class3 obj3 = FindObjClass3("someid");
           Class2 obj2 = DoSomethingObj3Class3(obj3); 
           return ((Class1) obj2).Clone();
        }
    }
