    [DataContract]
    [KnownType("GetKnownTypes")]
    public class Meeting
    {
        Contact MeetingContact{get;}
        private static Type[] GetKnownType()
        {
        return new Type[]{typeof(Client)};
        }
    }
