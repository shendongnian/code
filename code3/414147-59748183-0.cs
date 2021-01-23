public class Magic{
static Magic()
{
    BaseMethod();
}
public void BaseMethod(){
}
//runs BaseMethod before being executed
public void Method1(){
}
//runs BaseMethod before being executed
public void Method2(){
}
}
Here's the Microsoft doc:
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-constructors
