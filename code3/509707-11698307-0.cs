    public class Entity
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
    
        public static List<Entity> GetTree(int ID, List<Entity> ListToSearch)
        {
            List<Entity> result = new List<Entity>();
            
            result.AddRange(ListToSearch.Where<Entity>(x => x.ParentID == ID).ToList<Entity>());
    
            foreach (Entity current in result)
            {
                result.AddRange(GetTree(current.ID, ListToSearch);
            }
    
            result.Add(ListToSearch.Where<Entity>(x => x.ID == ID).Single<Entity>());
    
            return result;
        }
    }
