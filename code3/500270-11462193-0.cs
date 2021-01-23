    iCalendarSerializer serializer = new iCalendarSerializer();
    MemoryStream stream = new MemoryStream();
    using(stream)
    {
      serializer.Serialize(new iCalendar(), stream, System.Text.Encoding.UTF8);
    }
    byte[] buff = stream.ToArray();
