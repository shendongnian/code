    namespace XYZ.Core.Enum
    {
    public enum MasterEventType : int
    {
        Undefined = 0,  
        Logon = 1,
        Logoff = 2,   
     }
    }
    namespace XYZ.Core.Model
    {
    public class MasterUserEventLog  
    {
        // the rest is not relevant here....
        public MasterEventType EventType{ get; set; }       // what happened
    }
    {
