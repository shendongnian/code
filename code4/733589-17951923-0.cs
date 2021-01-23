    public class MessageInsert : ISerializable, ICloneable {}
    public class DateTimeInsert : MessageInsert {}
    public class TimeStampInsert : DateTimeInsert, ISerializable {}
    public class DateStampInsert : DateTimeInsert, ISerializable {}
    public class ClockInsert : DateTimeInsert, ISerializable {}
    public class CalendarInsert : DateTimeInsert, ISerializable {}
    public class DataInsert : MessageInsert, ISerializable {} 
    public class TokenInsert : DataInsert, ISerializable {}
    public class VariableInsert : DataInsert, ISerializable {}
