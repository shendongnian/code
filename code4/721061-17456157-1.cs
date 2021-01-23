    namespace ITHelperService
    {
    [DataContract]
    public class Service : IService
    {
        public void Test()
        {
         // This is the method that you can call from your client
        }
    
    }
    
     [DataContract(Name="CommandsEnums")]
        public enum CommandsEnums
        {
            [EnumMember]
            Get_IPConfig,
            [EnumMember]
            Get_IPConfig_all,
            Get_BIOSVersion,
            Get_JavaVersion,
            Get_RecentInstalledPrograms,
            Get_RecentEvents,
            Get_WEIScore,
            Do_Ping,
            Do_NSLookup
        }
    }
