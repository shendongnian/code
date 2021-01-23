    using Microsoft.CSharp;
	using System;
	using System.CodeDom;
	using System.Reflection;
	namespace CSTypeNames
	{
		class Program
		{
			static void Main(string[] args)
			{
				// Resolve reference to mscorlib.
				// int is an arbitrarily chosen type in mscorlib
				var mscorlib = Assembly.GetAssembly(typeof(int));
				using (var provider = new CSharpCodeProvider())
				{
					foreach (var type in mscorlib.DefinedTypes)
					{
						if (string.Equals(type.Namespace, "System"))
						{
							var typeRef = new CodeTypeReference(type);
							var csTypeName = provider.GetTypeOutput(typeRef);
							// Ignore qualified types.
							if (csTypeName.IndexOf('.') == -1)
							{
								Console.WriteLine(csTypeName + " : " + type.FullName);
							}
						}
					}
				}
				Console.ReadLine();
			}
		}
	}
