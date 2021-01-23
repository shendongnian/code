    public class Entity
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public static List<Entity> GetTree(int ID, List<Entity> ListToSearch, bool First = true)
        {
            List<Entity> FilteredEntities = new List<Entity>();
            
            FilteredEntities.AddRange(ListToSearch.Where<Entity>(x => x.ParentID == ID).ToList<Entity>());
            List<Entity> Temp = new List<Entity>();
            foreach (Entity current in FilteredEntities)
            {
                Temp.AddRange(GetTree(current.ID, ListToSearch, false));
            }
            FilteredEntities.AddRange(Temp);
            if (First)
            {
                FilteredEntities.Add(ListToSearch.Where<Entity>(x => x.ID == ID).Single<Entity>());
            }
            return FilteredEntities;
        }
    }
