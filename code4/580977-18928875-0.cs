            string Share = @"R:\Test\TestAssembly.dll";
            byte[] AssmBytes = File.ReadAllBytes(Share);
            Assembly a = Assembly.Load(AssmBytes);
            //Invoking a method from the loaded assembly
            var obj = a.CreateInstance("TestAssembly.Class1");
            obj.GetType().InvokeMember("HelloWorld", BindingFlags.InvokeMethod, null, obj, null);
