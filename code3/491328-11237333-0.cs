    public static class Defines
    {
       public static bool TryAction(Action pAction)
       {
          try { pAction(); return true; }
          catch(Exception exception) { PostException(exception); return false; }
       }
    }
    ...
    private void DoSomething(int pValue)
    {
       ...
    }
    private void MyControl_MyEvent(object pSender, MyEventArgs pEventArgs)
    {
       Defines.TryAction(() => DoSomething(pEventArgs.Data));
    }
