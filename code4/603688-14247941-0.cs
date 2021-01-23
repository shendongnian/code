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
    
                Reduce = results => 
                    from result in results
                    group result by new {result.Tag, result.PhotoId} into agg
                    select new TaggedPhotos
                    {
                        Tag = agg.Key.Tag,
                        PhotoId = agg.Key.PhotoId
                    };
            }
        }
    
        public class TaggedPhotos
        {
            public string Tag {get; set;}
            public string PhotoId {get; set;}
        }
