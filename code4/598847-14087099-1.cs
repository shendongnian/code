    using (var session = documentStore.OpenSession())
    {
        var album = new Album();
        session.Store(album);
        var photoA = new Photo { PhotoName = "A", AlbumId = album.Id };
        var photoB = new Photo { PhotoName = "B", AlbumId = album.Id };
        var photoC = new Photo { PhotoName = "C", AlbumId = album.Id };
        session.Store(photoA);
        session.Store(photoB);
        session.Store(photoC);
        session.Advanced.AddCascadeDeleteReference(album,
                                                   photoA.Id,
                                                   photoB.Id,
                                                   photoC.Id);
        session.SaveChanges();
    }
