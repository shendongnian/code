    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Dynamic;
    using FastMember;
    
    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main()
            {
                var list = new List<dynamic>();
                dynamic obj = new ExpandoObject();
                obj.Foo = 123;
                obj.Bar = "xyz";
                list.Add(obj);
                obj = new ExpandoObject();
                obj.Foo = 456;
                obj.Bar = "def";
                list.Add(obj);
                obj = new ExpandoObject();
                obj.Foo = 789;
                obj.Bar = "abc";
                list.Add(obj);
    
                var accessor = TypeAccessor.Create(
                    typeof(IDynamicMetaObjectProvider));
                string propName = "Bar";
                list.Sort((x,y) => Comparer.Default.Compare(
                    accessor[x, propName], accessor[y,propName]));
    
                foreach(var item in list) {
                    Console.WriteLine(item.Bar);
                }
            }
        }
    }
