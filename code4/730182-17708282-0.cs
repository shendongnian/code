    public abstract class AbstractFoo
    {
    }
    
    public class BarFoo : AbstractFoo 
    {
        public static string GetName()
        {
            return "Pretty Name For BarFoo";
        }
    }
     Type fooType = typeof(AbstractFoo);
     List<Assembly> assemblies = new List<Assembly>(AppDomain.CurrentDomain.GetAssemblies());
     IEnumerable<Type> allTypes = assemblies.SelectMany<Assembly, Type>(s => s.GetTypes());
     IEnumerable<Type> fooTypes = allTypes.Where(p => p.IsSubclassOf (fooType));
     foreach (Type thisType in fooTypes) 
     {
    
          MethodInfo method = thisType.GetMethod ("GetName", BindingFlags.Public | BindingFlags.Static);
          string name = (string) method.Invoke (null, null);
      // add to the list, anyhow names.Add (name);  
      }
