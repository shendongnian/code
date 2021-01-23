    void Save(ServerBlog sb)
    {
        using (var db = new LocalContext())
        {
            var clientBlog = new ClientBlog
            {
                Text = db.Text
                // or the same using AutoMapper
            };
            db.Blogs.Add(clientBlog):
        }
    }
