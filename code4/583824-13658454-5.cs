    //your program
    class Program
        {
            static void Main(string[] args)
            {
                //this is how you search in the folder
                foreach (string s in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*PlugIn.dll"))//getting plugins in base directory ending with PlugIn.dll
                {
                    Assembly aWrite = Assembly.LoadFrom(s);
                    //this is how you cast the plugin with the shared dll's interface
                    Type tWrite = aWrite.GetType("PlugInApp.plugInClass");
                    IWrite click = (IWrite)Activator.CreateInstance(tWrite);//you create the object
                    click.write();//you call the method
                }
            } 
        }
