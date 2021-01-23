    List<ContentType> contentTypes = new List<ContentType>();
    
    //Fill Your List With Names and IDs
    //Eg: contentTypes.Add(new ContentType(0,"Menu")) and so on and so forth then:
    foreach (ContentType contentType in contentTypes )
    {
            _uow.ContentTypes.Add(contentType);
    }
