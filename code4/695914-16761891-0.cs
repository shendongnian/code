    var settings = new JsonSerializerSettings
                   {
                       TypeNameHandling = TypeNameHandling.All,
                       TypeNameAssemblyFormat = FormatterAssemblyStyle.Full
                   };
    var json = JsonConvert.SerializeObject(object, Formatting.None, settings);
    var object = JsonConvert.DeserializeObject<MailMessageRequest>(message.Body, settings);
