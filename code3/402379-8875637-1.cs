    private FileClient CopyFileClientModel(FileClient fileClient) {
        return this.CopyFileClientModel(fileClient, c => c.Client);
    }
    private FileContact CopyFileClientModel(FileContact fileContact) {
        return this.CopyFileClientModel(fileContact, c => c.Client);
    }
    private TSource CopyFileClientModel<TSource>(TSource fileClientOrContact, Func<TSource, Contact> contactGetter) {
        var contact = contactGetter(fileClientOrContact);
        // Whatever else...
    }
