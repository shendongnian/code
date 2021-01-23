class MyClass : MyInterface
{
  void MyInterface.DoSomething(int param)
  {
    doSomething(param);
  }
  protected virtual void doSomething(int param)
  {
    ...
  }
}
class MyClass2 : MyClass
{
  protected override void doSomething(int param)
  {
    ...
    base.doSomething(param);
    ...
  }
}
