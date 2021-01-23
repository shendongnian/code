    private TSource CopyFileClientModel<TSource>(TSource fileClientOrContact)
    (
        dynamic d = fileClientOrContact;
        
        // Now you reach the Contact property
        var x = d.Contact;
    )
    
