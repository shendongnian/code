    void Main()
    {
        myTest t = new myTest();
        Console.WriteLine(t.member);
    }
    
    class myTest
    {
        public bool member {get; protected set;}
    }
    IL_0000:  newobj      UserQuery+myTest..ctor
    IL_0005:  stloc.0     // t
    IL_0006:  ldloc.0     // t
    IL_0007:  callvirt    UserQuery+myTest.get_member
    IL_000C:  call        System.Console.WriteLine
    
    myTest.get_member:
    IL_0000:  ldarg.0     
    IL_0001:  ldfld       UserQuery+myTest.<member>k__BackingField
    IL_0006:  ret         
    
    myTest.set_member:
    IL_0000:  ldarg.0     
    IL_0001:  ldarg.1     
    IL_0002:  stfld       UserQuery+myTest.<member>k__BackingField
    IL_0007:  ret         
    
    myTest..ctor:
    IL_0000:  ldarg.0     
    IL_0001:  call        System.Object..ctor
    IL_0006:  ret
