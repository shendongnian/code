	.class public auto ansi abstract sealed beforefieldinit TestClass
		extends [mscorlib]System.Object
	{
		// Nested Types
		.class nested private auto ansi abstract sealed beforefieldinit '<TestMethod>o__SiteContainer0'
			extends [mscorlib]System.Object
		{
			.custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = (
				01 00 00 00
			)
			// Fields
			.field public static class [System.Core]System.Runtime.CompilerServices.CallSite`1<class [mscorlib]System.Action`3<class [System.Core]System.Runtime.CompilerServices.CallSite, class [mscorlib]System.Type, object>> '<>p__Site1'
		} // end of class <TestMethod>o__SiteContainer0
		// Methods
		.method public hidebysig static 
			void Take (
				object o
			) cil managed 
		{
			// Method begins at RVA 0x2050
			// Code size 13 (0xd)
			.maxstack 8
			IL_0000: nop
			IL_0001: ldstr "Received an object"
			IL_0006: call void [mscorlib]System.Console::WriteLine(string)
			IL_000b: nop
			IL_000c: ret
		} // end of method TestClass::Take
		.method public hidebysig static 
			void Take (
				int32 i
			) cil managed 
		{
			// Method begins at RVA 0x205e
			// Code size 13 (0xd)
			.maxstack 8
			IL_0000: nop
			IL_0001: ldstr "Received an integer"
			IL_0006: call void [mscorlib]System.Console::WriteLine(string)
			IL_000b: nop
			IL_000c: ret
		} // end of method TestClass::Take
		.method public hidebysig static 
			void TestMethod () cil managed 
		{
			// Method begins at RVA 0x206c
			// Code size 129 (0x81)
			.maxstack 8
			.locals init (
				[0] object a,
				[1] object b,
				[2] class [Microsoft.CSharp]Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo[] CS$0$0000
			)
			IL_0000: nop
			IL_0001: ldc.i4.2
			IL_0002: box [mscorlib]System.Int32
			IL_0007: stloc.0
			IL_0008: ldloc.0
			IL_0009: call void TestClass::Take(object)
			IL_000e: nop
			IL_000f: ldc.i4.2
			IL_0010: box [mscorlib]System.Int32
			IL_0015: stloc.1
			IL_0016: ldsfld class [System.Core]System.Runtime.CompilerServices.CallSite`1<class [mscorlib]System.Action`3<class [System.Core]System.Runtime.CompilerServices.CallSite, class [mscorlib]System.Type, object>> TestClass/'<TestMethod>o__SiteContainer0'::'<>p__Site1'
			IL_001b: brtrue.s IL_0060
			IL_001d: ldc.i4 256
			IL_0022: ldstr "Take"
			IL_0027: ldnull
			IL_0028: ldtoken TestClass
			IL_002d: call class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
			IL_0032: ldc.i4.2
			IL_0033: newarr [Microsoft.CSharp]Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo
			IL_0038: stloc.2
			IL_0039: ldloc.2
			IL_003a: ldc.i4.0
			IL_003b: ldc.i4.s 33
			IL_003d: ldnull
			IL_003e: call class [Microsoft.CSharp]Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo [Microsoft.CSharp]Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo::Create(valuetype [Microsoft.CSharp]Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfoFlags, string)
			IL_0043: stelem.ref
			IL_0044: ldloc.2
			IL_0045: ldc.i4.1
			IL_0046: ldc.i4.0
			IL_0047: ldnull
			IL_0048: call class [Microsoft.CSharp]Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo [Microsoft.CSharp]Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo::Create(valuetype [Microsoft.CSharp]Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfoFlags, string)
			IL_004d: stelem.ref
			IL_004e: ldloc.2
			IL_004f: call class [System.Core]System.Runtime.CompilerServices.CallSiteBinder [Microsoft.CSharp]Microsoft.CSharp.RuntimeBinder.Binder::InvokeMember(valuetype [Microsoft.CSharp]Microsoft.CSharp.RuntimeBinder.CSharpBinderFlags, string, class [mscorlib]System.Collections.Generic.IEnumerable`1<class [mscorlib]System.Type>, class [mscorlib]System.Type, class [mscorlib]System.Collections.Generic.IEnumerable`1<class [Microsoft.CSharp]Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo>)
			IL_0054: call class [System.Core]System.Runtime.CompilerServices.CallSite`1<!0> class [System.Core]System.Runtime.CompilerServices.CallSite`1<class [mscorlib]System.Action`3<class [System.Core]System.Runtime.CompilerServices.CallSite, class [mscorlib]System.Type, object>>::Create(class [System.Core]System.Runtime.CompilerServices.CallSiteBinder)
			IL_0059: stsfld class [System.Core]System.Runtime.CompilerServices.CallSite`1<class [mscorlib]System.Action`3<class [System.Core]System.Runtime.CompilerServices.CallSite, class [mscorlib]System.Type, object>> TestClass/'<TestMethod>o__SiteContainer0'::'<>p__Site1'
			IL_005e: br.s IL_0060
			IL_0060: ldsfld class [System.Core]System.Runtime.CompilerServices.CallSite`1<class [mscorlib]System.Action`3<class [System.Core]System.Runtime.CompilerServices.CallSite, class [mscorlib]System.Type, object>> TestClass/'<TestMethod>o__SiteContainer0'::'<>p__Site1'
			IL_0065: ldfld !0 class [System.Core]System.Runtime.CompilerServices.CallSite`1<class [mscorlib]System.Action`3<class [System.Core]System.Runtime.CompilerServices.CallSite, class [mscorlib]System.Type, object>>::Target
			IL_006a: ldsfld class [System.Core]System.Runtime.CompilerServices.CallSite`1<class [mscorlib]System.Action`3<class [System.Core]System.Runtime.CompilerServices.CallSite, class [mscorlib]System.Type, object>> TestClass/'<TestMethod>o__SiteContainer0'::'<>p__Site1'
			IL_006f: ldtoken TestClass
			IL_0074: call class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
			IL_0079: ldloc.1
			IL_007a: callvirt instance void class [mscorlib]System.Action`3<class [System.Core]System.Runtime.CompilerServices.CallSite, class [mscorlib]System.Type, object>::Invoke(!0, !1, !2)
			IL_007f: nop
			IL_0080: ret
		} // end of method TestClass::TestMethod
	} // end of class TestClass
