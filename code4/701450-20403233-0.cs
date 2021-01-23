    using System.Collections.Generic;
    namespace PCL {
      public interface IAppDomain {
        IList<IAssembly> GetAssemblies();
      }
      public interface IAssembly {
        string GetName();
      }
      public class AppDomainWrapper {
        public static IAppDomain Instance { get; set; }
      }
    }
