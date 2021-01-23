    public void SomeMethod()
    {
        var name = "Hello";
        var motto = "World";                       
        using (var docStore = new DocumentStore("localhost", 8080).Initialize())
        using (var session = documentStore.OpenSession()){
            session.Store(new Company { Name = name, Motto = motto });;
            session.SaveChanges();
        }
    }
