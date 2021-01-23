            Assembly assembly = System.Reflection.Assembly.GetAssembly(typeof(String));
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            ObjectHandle oh = Activator.CreateInstanceFrom("AssemblyName.dll", "namespace.class");
            object o = oh.Unwrap();
            Type to = o.GetType();
            if (fileVersionInfo.FileMajorPart >= 3)
            {
                to.InvokeMember("Method X", BindingFlags.InvokeMethod, null, o, null);
            }
            else
            {
                to.InvokeMember("Method Y", BindingFlags.InvokeMethod, null, o, null);
            }
