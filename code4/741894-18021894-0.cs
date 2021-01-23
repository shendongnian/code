    using System;
    using System.Collections.Generic;
 
    public class Test
    {
        static void Main()
        {
            var m = new Helper<string>();
            m.Add(new ConcreteClass("concrete"));
 
            var n = m.GetFirstData();
            Console.WriteLine(n);
        }
 
        class Helper<T>
        {
            List<AbstractClass<T>> data = new List<AbstractClass<T>>();
 
            public void Add(AbstractClass<T> thing) 
            {
                this.data.Add(thing);
            }
 
            public T GetFirstData()
            {
                return this.data[0].InfoData;
            }
        }
 
        class AbstractClass<T>
        {
            public T InfoData { get; set; }
        }
 
        class ConcreteClass : AbstractClass<string>
        {
            public ConcreteClass(string infoData)
            {
                InfoData = infoData;
            }
        }
    }
