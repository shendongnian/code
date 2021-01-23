    using System;
    using System.Collections.Generic;
    
    namespace DoesItCompile
    {
        class SomeClass
        {
            private object param1;
            private object param2;
            private SomeClass() { }
            public SomeClass(string param1, string param2)
            {
                this.param1 = param1;
                this.param2 = param2;
            }
    
            public override bool Equals(object oThat)
            {
                if (!(oThat is SomeClass))
                    return false;
                SomeClass scThat = (SomeClass)oThat;
                if (!string.Equals(this.param1, scThat.param1))
                    return false;
                if (!string.Equals(this.param2, scThat.param2))
                    return false;
                return true;
            }
    
            public override int GetHashCode()
            {
                return this.param1.GetHashCode() ^ this.param2.GetHashCode();
            }
        }
    
        class SomeClass2
        {
            private List<SomeClass> myList = new List<SomeClass>();
    
            public void Add(SomeClass someclass)
            {
                myList.Add(someclass);
            }
    
            public void Remove(SomeClass someClass)
            {
                // this part always rises an exception
                if (!myList.Contains(someClass))
                    throw new System.ArgumentException("some error");
    
                else myList.Remove(someClass);
            }
        }
    
        class MainClass
        {
            public static void Main(string[] args)
            {
                var _someClass = new SomeClass2();
    
                _someClass.Add(new SomeClass("aaa", "bbb"));
    
                try
                {
                    _someClass.Remove(new SomeClass("aaa", "bbb"));
    
                    Console.WriteLine("Have a nice president's day.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
    
                Console.ReadKey();
            }
        }
    }
