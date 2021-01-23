    using System;
    using System.Collections.Generic;
    
    class Class1 { }
    
    class ClassA : Class1 { }
    class ClassB : Class1 { }
    
    class Program
    {
        private static readonly Dictionary<string, Type> _typeMap =
            new Dictionary<string, Type>
            {
                { "A", typeof(ClassA) }, 
                { "B", typeof(ClassB) }, 
            };
        
        private static readonly Dictionary<string, Func<Class1>> _funcMap =
            new Dictionary<string, Func<Class1>>
            {
                { "A", () => new ClassA() }, 
                { "B", () => new ClassB() }, 
            };
    
        Class1 CreateViaTypeMap(string typeName)
        {
            var type = _typeMap[typeName];
            return Activator.CreateInstance(type) as Class1;
        }
    
        Class1 CreateViaFuncMap(string typeName)
        {
            var func = _funcMap[typeName];
            return func();
        }
    }
