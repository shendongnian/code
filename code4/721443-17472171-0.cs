     // example looks close to yout issue, (checking removed for brevity) 
     // call method GetRespository<poco>  dynamically on any object that implements ILuw
     // the result passed back is also dynamic.  For obvious reasons.    
     public static dynamic GetDynamicRepository(ILuw iLuw, string pocoFullName)  {
            //null checks removed for demo....
            var pocoType = Type.GetType(pocoFullName);
            MethodInfo method = typeof(ILuw).GetMethod("GetRepository");
            MethodInfo generic = method.MakeGenericMethod(pocoType);
            var IRepOfT = generic.Invoke(iLuw, null);
            dynamic repOfT = IRepOfT;
            return repOfT;
        }
