<!-- language: c# -->
    //load dll
System.Reflection.Assembly myDllAssembly =
    System.Reflection.Assembly.LoadFile("myspeciallibrary.dll");
//create object
Object MyDLLObjectInstance;
//initialize object
if (myDllAssembly.ImageRuntimeVersion == "version2")
{
    MyDLLObjectInstance = (Object)myDllAssembly.CreateInstance("MyDLLNamespace.MyDLLObject");
}
else
{
    MyDLLObjectInstance = (Object)myDllAssembly.CreateInstance("MyDLLNamespace.NewNameSpace.MyDLLObject");
}
