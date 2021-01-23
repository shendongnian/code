    // pushes comma
    L_0017: ldstr ", "
    
    // pushes names variable 
    L_001c: ldloc.1 
    // pushes foo variable
    L_001d: ldloc.0 
    // pushes pointer to the extension method
    L_001e: ldftn string ConsoleApplication3.Extensions::GetName(class ConsoleApplication3.Foo, string)
    // pops the instance of foo and the extension method pointer and pushes delegate
    L_0024: newobj instance void [mscorlib]System.Func`2<string, string>::.ctor(object, native int)
    
    // pops the delegate and the names variable 
    // calls Linq.Enumerable.Select extension method
    // pops the result (IEnumerable<string>)
    L_0029: call class [mscorlib]System.Collections.Generic.IEnumerable`1<!!1> [System.Core]System.Linq.Enumerable::Select<string, string>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>, class [mscorlib]System.Func`2<!!0, !!1>)
    
    // pops comma, the IEnumerable<string>
    // pushes joined string
    L_002e: call string [mscorlib]System.String::Join(string, class [mscorlib]System.Collections.Generic.IEnumerable`1<string>)
    
    // pops joined string and displays it
    L_0033: call void [mscorlib]System.Console::WriteLine(string)
    
    // method finishes
    L_0038: ret 
