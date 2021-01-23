    public class SpecialXmlLayout : XmlLayoutBase
    {
    protected override void FormatXml(XmlWriter writer, LoggingEvent loggingEvent)
    {
    Message message = loggingEvent.MessageObject as Message;
    writer.WriteStartElement("LoggingEvent");
    writer.WriteElementString("Message", GetMessage(message));
    // ... write other things
    writer.WriteEndElement();
    }
    }
