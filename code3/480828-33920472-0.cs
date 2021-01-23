    namespace Z_Dll_1
    {
        public class PublicBaseClassAssemblyOne
        {
            internal int _myinternal = 200;
            protected internal int _protectedinternal = 100;
            protected int _myProtected = 123;
            private int _myPrivate = 2;
            public int _myPublic = 45;
        }
    
        public class DerivedClassAssemblyOne : PublicBaseClassAssemblyOne
        {
            protected internal int intM = 10;
        }
    
        internal class MyInternalClass
        {
            public void MyMethod()
            {
                Console.WriteLine("Method one with internal class");
                PublicBaseClassAssemblyOne cl1 = new PublicBaseClassAssemblyOne();
                cl1._myinternal = 1000; //Internal type is available since it is in same assembly
                cl1._protectedinternal = 10; // protected internal is available
                cl1._myPublic = 2;  // Public OK
                //cl1.myPrivate = ?? // nor available since it is private
    
                DerivedClassAssemblyOne drOne = new DerivedClassAssemblyOne();
                drOne._myinternal = 30; // Internal and available from derived class
                drOne._myPublic = 1; // Public 
                drOne._protectedinternal = 2; // Able to be accessed from same assembly or derived class from other assembly
            }
        }
    }
    
