    public class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
    }
    
    public static void UndoDelete(IEnumerable<Entity> fullList, int[] removedIds)
    {
        foreach(var entity in fullList.Where(e => removedIds.Contains(e.Id)))
        {
            entity.IsDelete = false;
        }
    }
