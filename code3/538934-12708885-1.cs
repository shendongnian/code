    var alias = "aliasOfOptionalField";
    var value = string.Empty;
    var docType = "Textpage";
    
    DocumentType dt = DocumentType.GetByAlias(docType); 
    User author = User.GetUser(0); 
    Document doc = Document.MakeNew("My new document", dt, author, 1018); 
    doc.Publish(author);
    umbraco.library.UpdateDocumentCache(doc.Id);
    
    var newProperty = dt.AddPropertyType(new DataTypeDefinition(-49), alias, "test prop");
    
    if (doc.HasProperty(alias))
    {
       doc.getProperty(alias).Value = value;
       doc.Publish(new User(0));
       library.UpdateDocumentCache(doc.Id);
    }
