    public class AppDomainWrapperInstance : IAppDomain {
      IList<IAssembly> GetAssemblies() {
        var result = new List<IAssembly>();
        foreach (var assembly in System.AppDomain.CurrentDomain.GetAssemblies()) {
          result.Add(new AssemblyWrapper(assembly));
        }
        return result;
      }
    }
    public class AssemblyWrapper : IAssembly {
      private Assembly m_Assembly;
      public AssemblyWrapper(Assembly assembly) {
        m_Assembly = assembly;
      }
      public string GetName() {
        return m_Assembly.GetName().ToString();
      }
    }
