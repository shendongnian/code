    using System;
    using System.Windows.Forms;
    
    class Test
    {
        static void Main()
        {
            string name = typeof(Form).AssemblyQualifiedName;
            Console.WriteLine(name);
    
            Type type = Type.GetType(name);
            Console.WriteLine(type);
        }
    }
    Output:
    
    System.Windows.Forms.Form, System.Windows.Forms, Version=4.0.0.0, Culture=neutral,
    PublicKeyToken=b77a5c561934e089
    System.Windows.Forms.Form
