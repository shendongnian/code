    public enum UserMode {Mode1, Mode2};
    
    public interface iType
    {
       string Expression {get;}
       string OriginalString {get; set;}
       string Transform(UserMode Mode);
       iType getNewInstance(string OriginalString);
    
    }
    
    public class Type1 : iType
    {
       public string Expression {get { return "RegularExpression"; }}
       public string OriginalString {get; set;}
       //Add any other private members you need to accomplish your work here.
       public string Transform(UserMode Mode)
       {
          switch(Mode)
          {
             case UserMode.Mode1:
                 //write the transformation code for this scenario
                 return ResultString;
                 break;
          }
       }
    
       public iType getNewInstance(string Original)
       {
         return (iType)(new Type1(){ OriginalString = Original });
       }
    }
    
    public static class TypeFactory
    {
       public static List<iType> GetTypeList()
       {
           List<iType> types = new List<iType>();
           types.AddRange(from assembly in AppDomain.CurrentDomain.GetAssemblies()
                          from t in assembly.GetTypes()
                          where t.IsClass && t.GetInterfaces().Contains(typeof(iType))
                          select Activator.CreateInstance(t) as iType);
    
           return types;
        }
    }
