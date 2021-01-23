    string path = ApplicationMapPath+ objDLLName + ".dll";
    System.Reflection.Assembly a = System.Reflection.Assembly.LoadFile(path);
    Type t = a.GetType("<namespace>.<Class>");
    object instance = a.CreateInstance("<namespace>.<Class>");
    
    MethodInfo m = t.GetMethod("<FuncName>");// Call the method
    object res = m.Invoke(instance, new object[] { txtBox.Text }); // Get the result here
 
