     public class TaggedPhotosIndex:AbstractIndexCreationTask<Photo, TaggedPhotos>
        {
            public TaggedPhotosIndex()
            {
                Map = photos =>                
                    from p in Photos
                    from t in p.Tags
                    select new TaggedPhotos
                    {
                        Tag = t,
                        PhotoId = p.Id
                    };
            }
        }
    
        public class TaggedPhotos
        {
            public string Tag {get; set;}
            public string PhotoId {get; set;}
        }
