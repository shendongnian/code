    public class SPFile : IMyNewInterface  {
       .....
    }
    public class SPFolder : IMyNewInterface  {
       ...
    }
    public static void SetFolderOrderValue<T>(T item, int value, 
                  Report reportObject) where T : IMyNewInterface    {
         ...
    }
