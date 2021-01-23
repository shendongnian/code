    public void Save<T>(T entity) where T : class
    {
        Save((dynamic)entity);
    }
    private void Save(LibraryItem lib){}
    private void Save(ProcessName proc){}
    private void Save(ProductType type){}
    private void Save(Folder folder){}
