    var data = @"<Access>
       <Phone hasTextField=""true"">
          <Item description=""Skype"" />
          <Item description=""IP Phone"" />
       </Phone>
       <Computer>
          <Item description=""PC"" />
          <Item description=""Laptop"" />
       </Computer>
    </Access>";
    
    var serializer = new XmlSerializer(typeof(Access));
    
    Access access;
    
    using(var stream = new StringReader(data))
    using(var reader = XmlReader.Create(stream))
    {
        access = (Access)serializer.Deserialize(reader);
    }
