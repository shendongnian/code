    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using MINT;
    using MbUnit.Framework;
    using Mono.Reflection;
	// enumerating Fixtures
	foreach (Type fixture in _assembly.GetTypes().Where(t => t.GetCustomAttributes(typeof(TestFixtureAttribute), false).Length > 0))
	{
		// enumerating Test Methods
		foreach (var testMethod in fixture.GetMethods().Where(m => m.GetCustomAttributes(typeof(TestAttribute),false).Length > 0))
		{
			var instructions = testMethod.GetInstructions().Where(
				i => i.OpCode.OpCodeType == OpCodeType.Objmodel &&
				((ConstructorInfo)i.Operand).DeclaringType.BaseType.Equals(typeof(BaseAction))).
				Select(i => i.Operand).Cast<ConstructorInfo>();
			// enumerating actions!
			foreach (ConstructorInfo action in instructions)
			{
				string actionName = action.DeclaringType.Name;
			}
		}
	}
