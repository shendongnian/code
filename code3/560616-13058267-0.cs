    > using System.Reflection;
    > var a = 1; 
    > var b = "c";
    > var c = from type in Assembly.GetExecutingAssembly().DefinedTypes.Reverse()
          from variable in type.GetFields(BindingFlags.Instance | BindingFlags.Public)
          select variable;
    > foreach (var info in c ) { 
         if (info.FieldType != typeof(Roslyn.Services.InteractiveHostObject)) {
             Console.WriteLine(info);
         }
      }
    System.Collections.Generic.IEnumerable`1[System.Reflection.FieldInfo] c
    System.String b
    Int32 a
