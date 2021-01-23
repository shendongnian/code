    public class BaseClass
    {
      public virtual Task Logoff()
      {
        DoLogoff();
        return Task.FromResult(false);
      }
    }
    public DerivedClass: BaseClass
    {
      public override async Task Logoff()
      {
        await SomeWoAsyncWork();
        await base.Logoff();
      }
    }
