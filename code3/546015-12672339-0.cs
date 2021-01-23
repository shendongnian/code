            List<ArtistAndTags> List1 = new List<ArtistAndTags>(); 
            List<ArtistAndTags> List2 = new List<ArtistAndTags>();
            var intersectedList = new List<ArtistAndTags>();
            foreach (var item1 in List1)
            {
                foreach (var item2 in List2)
                {
                    if (item2.Tags.Intersect(item1.Tags).Any()))
                    {
                        intersectedList.Add(item1);
                        intersectedList.Add(item2);
                    }
                }
            }
            var result = intersectedList.Select(x => x.ArtistName).ToList();
