    public static void ConfigureAppDomain(string[] args)
    {
        string unknownAppPath = args[0];
        AppDomain.CurrentDomain.DoCallBack(delegate()
        {
            //check that the new assembly is signed with the same public key
            Assembly unknownAsm = AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(unknownAppPath));
            //get the new assembly public key
            byte[] unknownKeyBytes = unknownAsm.GetName().GetPublicKey();
            string unknownKeyStr = BitConverter.ToString(unknownKeyBytes);
 
            //get the current public key
            Assembly asm = Assembly.GetExecutingAssembly();
            AssemblyName aname = asm.GetName();
            byte[] pubKey = aname.GetPublicKey();
            string hexKeyStr = BitConverter.ToString(pubKey);
            if (hexKeyStr == unknownKeyStr)
            {
                //keys match so execute a method
                Type classType = unknownAsm.GetType("namespace.classname");
                classType.InvokeMember("MethodNameToInvoke", BindingFlags.InvokeMethod, null, null, null);
            }
        });
    }
