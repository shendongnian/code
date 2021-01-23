        public static string getStringByName(string var)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string resName = asm.GetName().Name + ".Properties.Resources";
            var rm = new ResourceManager("ValhallaLib.StringResource", asm);
            return rm.GetString(var);
        }
