// Pattern #1
void FancyDoSomething(MethodInvoker ThingToDo)
{
  try
  {
    PrepareToDoSomething();
    ThingToDo.Invoke(); // The ".Invoke" is optional; the parens aren't.
  }
  finally
  {
    Cleanup();
  }
}
void myCode(void)
{
  FancyDoSomething( () => {Stuff to do goes here});
}
// Pattern #2:
// Define an ActionWrapper so its constructor prepares to do something
// and its Dispose method does the required cleanup.  Then...
void myCode(void)
{
  using(var wrap = new ActionWrapper())
  {
    Stuff to do goes here
  }
}
