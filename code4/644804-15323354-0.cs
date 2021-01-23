    // s is a qualified type name, like "BankNamespace.Bank1"
    var customers = (List<string>)
            Type.GetType(s).InvokeMember("getCustomers",
                 System.Reflection.BindingFlags.Static |
                 System.Reflection.BindingFlags.InvokeMethod |
                 System.Reflection.BindingFlags.Public, // assume method is public
                 null, null, null);
