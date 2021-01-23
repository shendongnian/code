    var doc = XDocument.Load(textReader);
    foreach (var commandXml in doc.Descendants("Command"))
    {
        var command = new ATAPassThroughCommands();
        var name = commandXml.Descendants("Name").Single();
        // I'm not sure what this does but it looks important...
        CommandListContext.Add(name); 
        command.m_Name = name.Value;
        command.m_CMD = 
             Convert.ToByte(commandXml.Descendants("CMD").Single().Value, 16);
        command.m_Feature = 
             Convert.ToByte(commandXml.Descendants("Feature").Single().Value, 16);
        m_ATACommands.Add(command);
    }
