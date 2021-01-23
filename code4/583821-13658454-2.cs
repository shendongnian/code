    //your program
    class Program
        {
            static void Main(string[] args)
            {
                foreach (string s in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*PlugIn.dll"))//getting plugins in base directory ending with PlugIn.dll
                {
                    Assembly aWrite = Assembly.LoadFrom(s);
                    Type tWrite = aWrite.GetType("PlugInApp.plugInClass");
                    IWrite click = (IWrite)Activator.CreateInstance(tWrite);
                    click.write();
                }
            } 
        }
