    namespace SampleNamespace.Web.Services
    {
      public partial class MyDomainContext
      {
        partial void OnCreated()
        {
          TimeSpan tenMinutes = new TimeSpan(0, 10, 0);
          WcfTimeoutUtility.ChangeWcfSendTimeout(this, tenMinutes);
        }
      }
    }
