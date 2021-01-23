    public struct Test
    {
         public static void SomeMethod(){}
    }
    public static void Main()
    {         
         Test? Test = new Test();
         Test.SomeMethod();//ERROR... Test does not have method SomeMethod
    }
