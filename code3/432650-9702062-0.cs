    public interface IManageMessageFailures
{
   
    void SerializationFailedForMessage(TransportMessage message, Exception e);
    void ProcessingAlwaysFailsForMessage(TransportMessage message, Exception e);
