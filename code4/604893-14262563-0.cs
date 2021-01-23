    using (var session = RavenDocumentStore.OpenSession())
    {
        var time = session.Query<Exampleusers>()
            .Where(x => x.Username == userName).FirstOrDefault();
        var temp = time.Id;
        var data = session.Load<Exampleusers>(
            string.Format("Exampleusers/{0}", temp));
        data.Expiration = DateTime.Now;
        session.Store(data);
        session.SaveChanges();
}
