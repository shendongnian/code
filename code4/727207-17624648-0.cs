    public enum TaskType : int
    {
        None = 100,
        Install = 101,
        Decommission = 102,
        Modify = 103,
        Rename = 104,
        Move = 105,
        Incident = 106,
        Other = 107
    };
    public class ProvisioningListModel
    {
        public int TaskTypeProp { get; set; }
    
        public ProvisioningListModel(Task task)
        {
            TaskTypeProp = (int)task.TaskType;
        }
    }
