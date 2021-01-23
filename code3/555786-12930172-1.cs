    public abstract class TAbstract
    {
       public abstract int RunId {get; set;}
    }
    
    public class TChemistry : TAbstract
    {
        public override int RunId {get; set;}
    }
    
    public class TDrillSpan : TAbstract
    {
       public override int RunId {get; set;}
    }
    
    Type T = AllDrillTypes[13] as TAbstract;
    var LC = Activator.CreateInstance( typeof(List<>).MakeGenericType( T ) );
    MethodInfo M = T.GetMethod("FindAll", BindingFlags.Public | BindingFlags.Static, null, new Type[] { }, null);    
    LC = M.Invoke(null, new object[] { });
    
    var genericList = ((List<TAbstract>) LC);
    var LingLC = from obj in genericList where obj.RunID == 1001 select obj;
