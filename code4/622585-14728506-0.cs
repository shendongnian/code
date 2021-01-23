Well what you have to "import" (use) is the namespace of MyClass not the class name itself. If both classes are in the same namespace, you don't have to "import" it.
Definition MyClass.cs
namespace Ns1
{
  public class MyClass
  {
    ...
  }
}
Usage AnotherClass.cs
using Ns1;
namespace AnotherNs
{
  public class AnotherClass
  {
    public AnotherClass()
    {
      var myInst = new MyClass();
    }
  }
}
