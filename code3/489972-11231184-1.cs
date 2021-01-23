     public IEnumerable<Place> Merge(params List<Place>[] lists)
     {
         HashSet<int> _ids = new HashSet<int>();
         foreach(List<Place> list in lists)
         {
             foreach(Place place in list)
             {
                 if (!_ids.Contains(place.Id))
                 {
                     _ids.Add(place.Id);
                     yield return place;
                 }
             }
         }
     }
