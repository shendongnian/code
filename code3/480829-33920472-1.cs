    namespace Z_Dll_2
    {
        public class ClassAssembly2
        {
            public ClassAssembly2()
            {
                PublicBaseClassAssemblyOne classfromOtherAssembly = new PublicBaseClassAssemblyOne();
                classfromOtherAssembly._myPublic = 0; //Only public is available
            }
        }
    
        public class ClassDerivedFromOtherAssemblyClass : PublicBaseClassAssemblyOne
        {
            public ClassDerivedFromOtherAssemblyClass()
            {
            }
            void ClassDerivedFromOtherAssemblyClassTestMethod()
            {
                //_myinternal = 200; // can't access since it was internal to other assembly
                _protectedinternal = 100; // this can be accessed as it is  derived class from other class that has protected internal 
                _myProtected = 123; // Ordinary protected data accessed from derived class
                //_myPrivate = 2; //Private member can't be accessed from  derived class
                _myPublic = 45; // Public can be accessed anyway
    
                //Try to create an instance of internal class
                //MyInternalClass intClass = new MyInternalClass(); //Not accessible from this assembly
            }
        }
    }
