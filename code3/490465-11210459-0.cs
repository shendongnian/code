    public class Place_ByLocationsAndCategoryId : AbstractIndexCreationTask<Place> {
        public Place_ByLocationsAndCategoryId() {
            Map = places => from p in places
                                    select new { Categories_Id =  p.Categories.Select(x=>x.Id), _ = Raven.Database.Indexing.SpatialIndex.Generate(p.Location.Lat, p.Location.Lng) };
        }
    }
