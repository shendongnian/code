    public class Equipment {
        public int ProcessId { get; set; }
        public string Name { get; set; }
    }
    public class WorkflowItem {
        public Equipment { get; set; }
        public void LoadEquipmentFrom(IEnumerable<Equipment> cache){
            var equipment = cache.FirstOrDefault(e => e.ProcessId == Equipment.ProcessId);
            if(equipment != null)
                Equipment.Name = equipment.Name;
        }
    }
