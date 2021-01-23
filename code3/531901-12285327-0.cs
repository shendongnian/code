    var doc = XElement.Parse(
        @"<PolicyChangeSet schemaVersion='2.1' username='' description=''>
        <Note>
            <Content></Content>
        </Note>
        <Attachments>
            <Attachment name='' contentType=''>
            <Description></Description>
            <Location></Location>
            </Attachment>
        </Attachments>
        </PolicyChangeSet>");
    
    doc.Descendants("Note")
       .Descendants("Content").First().Value = "foo";
    var attachment = doc.Descendants("Attachments")
                        .Descendants("Attachment").First();
    
    attachment.Attributes("name").First().Value = "bar";
    attachment.Attributes("contentType").First().Value = "baz";
    ...
    doc.Save(...);
    
