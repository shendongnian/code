	IL_0000: newobj instance void class [mscorlib]System.Collections.Generic.List`1<string>::.ctor()
	IL_0005: stloc.0
	IL_0006: ldloc.0
	IL_0007: ldsfld class [mscorlib]System.Func`2<string, bool> ConsoleApplication2.Program::'CS$<>9__CachedAnonymousMethodDelegate3'
	IL_000c: brtrue.s IL_001f
	IL_000e: ldnull
	IL_000f: ldftn bool ConsoleApplication2.Program::'<Main>b__0'(string)
	IL_0015: newobj instance void class [mscorlib]System.Func`2<string, bool>::.ctor(object, native int)
	IL_001a: stsfld class [mscorlib]System.Func`2<string, bool> ConsoleApplication2.Program::'CS$<>9__CachedAnonymousMethodDelegate3'
	IL_001f: ldsfld class [mscorlib]System.Func`2<string, bool> ConsoleApplication2.Program::'CS$<>9__CachedAnonymousMethodDelegate3'
	IL_0024: call class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> [System.Core]System.Linq.Enumerable::Where<string>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>, class [mscorlib]System.Func`2<!!0, bool>)
	IL_0029: ldsfld class [mscorlib]System.Func`2<string, bool> ConsoleApplication2.Program::'CS$<>9__CachedAnonymousMethodDelegate4'
	IL_002e: brtrue.s IL_0041
	IL_0030: ldnull
	IL_0031: ldftn bool ConsoleApplication2.Program::'<Main>b__1'(string)
	IL_0037: newobj instance void class [mscorlib]System.Func`2<string, bool>::.ctor(object, native int)
	IL_003c: stsfld class [mscorlib]System.Func`2<string, bool> ConsoleApplication2.Program::'CS$<>9__CachedAnonymousMethodDelegate4'
	IL_0041: ldsfld class [mscorlib]System.Func`2<string, bool> ConsoleApplication2.Program::'CS$<>9__CachedAnonymousMethodDelegate4'
	IL_0046: call class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> [System.Core]System.Linq.Enumerable::Where<string>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>, class [mscorlib]System.Func`2<!!0, bool>)
	IL_004b: ldsfld class [mscorlib]System.Func`2<string, bool> ConsoleApplication2.Program::'CS$<>9__CachedAnonymousMethodDelegate5'
	IL_0050: brtrue.s IL_0063
	IL_0052: ldnull
	IL_0053: ldftn bool ConsoleApplication2.Program::'<Main>b__2'(string)
	IL_0059: newobj instance void class [mscorlib]System.Func`2<string, bool>::.ctor(object, native int)
	IL_005e: stsfld class [mscorlib]System.Func`2<string, bool> ConsoleApplication2.Program::'CS$<>9__CachedAnonymousMethodDelegate5'
	IL_0063: ldsfld class [mscorlib]System.Func`2<string, bool> ConsoleApplication2.Program::'CS$<>9__CachedAnonymousMethodDelegate5'
	IL_0068: call class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0> [System.Core]System.Linq.Enumerable::Where<string>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>, class [mscorlib]System.Func`2<!!0, bool>)
	IL_006d: pop
	IL_006e: ret
