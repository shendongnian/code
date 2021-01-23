    public interface IUtility {
        public static IUtility CreateAndRegister(string id);
    }
    public Class SomeObj : IUtility
    {
           //Implement method
           public static SomeObj CreateAndRegister(string id)
           {
                 //Create Object
           }
     }
