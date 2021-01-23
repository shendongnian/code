     for (int i = 0; i < photoids.Count; i++)
        {              
                MyPhoto mf = new MyPhoto();
                mf.photoId = photoids[i];
                mf.source = "flickr";
                var query = from b in db.FlickrUsers
                            where b.nsid == flickruserid
                            select b;
                FlickrUser fUser = query.FirstOrDefault();
                mf.FlickrUserId = fUser.nsid;
                db.MyPhotos.Add(mf);               
        }
    db.SubmitChanges();
