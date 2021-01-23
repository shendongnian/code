    static class Globals
    {
       private static Dictionary<string, MySessionObjectType> sessions;
  
       public static MySessionObjectType GetSessionData(string SessionID){...}
       public static void SetSessionData
                             (string SessionID, MySessionObjectType sessionData){...}
    }
