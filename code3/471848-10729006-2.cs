    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
    
    namespace ConsoleApplication3
    {
        using System.Collections;
        using System.Diagnostics;
        using System.Globalization;
        using System.Numerics;
        using System.Xml.Linq;
    
        public class Program
        {
    
            public class Person
            {
                private string _name = string.Empty;
    
                private int _age = 0;
    
                private bool _isMale = true;
    
                public Person(string name, int age, bool isMale)
                {
                    this.Name = name;
                    this.Age = age;
                    this.IsMale = isMale;
                }
    
                public string Name
                {
                    get
                    {
                        return this._name;
                    }
                    set
                    {
                        this._name = value;
                    }
                }
    
                public int Age
                {
                    get
                    {
                        return this._age;
                    }
                    set
                    {
                        this._age = value;
                    }
                }
    
                public bool IsMale
                {
                    get
                    {
                        return this._isMale;
                    }
                    set
                    {
                        this._isMale = value;
                    }
                }
            }
    
            private static void Main(string[] args)
            {
                var myDictionary = new Dictionary<string, Person>();
                myDictionary.Add("notRichard", new Program.Person("Richard1", 26, true));
                myDictionary.Add("notRichard1", new Program.Person("Richard2", 27, true));
                myDictionary.Add("notRichard2", new Program.Person("Richard3", 28, true));
                myDictionary.Add("notRichard3", new Program.Person("Richard4", 29, true));
                // usage
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for(int i = 0; i < 100000000; i++)
                {
                    var myValue = myDictionary.GetValueOrDefault("Richard", new Program.Person("Richard", 25, true));
                }
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < 100000000; i++)
                {
                    var myValue = myDictionary.GetValueOrDefault("Richard", ()=> new Program.Person("Richard", 25, true));
                }
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                Console.ReadKey();
            }
        }
        public static class Ex
        {
            public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> source, TKey key, TValue @default)
            {
                if (source.ContainsKey(key))
                {
                    return source[key];
                }
                return @default;
            }
            public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> source, TKey key, Func<TValue> defaultSelector)
            {
                if (source.ContainsKey(key))
                {
                    return source[key];
                }
                return defaultSelector();
            }
    
           
        }
    }
