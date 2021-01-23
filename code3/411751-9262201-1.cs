    public void RunMacro(object[] args){
    objWord.GetType().InvokeMember("Run",
    System.Reflection.BindingFlags.Default |
    System.Reflection.BindingFlags.InvokeMethod,
    null, objWord, args);}
