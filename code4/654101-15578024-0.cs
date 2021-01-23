        public IQueryable<Album> Get()
        {
            return (from a in _entities.Albums
                    select new Album()
                        {
                            Id = a.Id,
                            UserId  = a.UserId,
                            Name  = a.Name,
                            Created  = a.Created,
                            LastEdit  = a.LastEdit,
                            Description  = a.Description,
                            Views  = a.Views,
                            Location  = a.Location,
                            Photoshoot  = a.Photoshoot,
                            Cover = (from ai in _imageRepository.Get() where ai.AlbumId == a.Id orderby ai.Cover descending, ai.Id ascending select ai).FirstOrDefault(),
                        });
        }
