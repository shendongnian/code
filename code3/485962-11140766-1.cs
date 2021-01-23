        using System.Linq.Dynamic;
        public class DynamicColumns : BaseEntity
        {
            public string User { get; set; }
            public string TaskId { get; set; }
            public string Project { get; set; }
            public string Priority { get; set; }
            public string TaskType { get; set; }
            public string Version { get; set; }
            public string Module { get; set; }
            public string Subject { get; set; }
            public string Details { get; set; }
            public string FileName { get; set; }
            public string Status { get; set; }          
            public string AssignedBy { get; set; }
            public string AssignedTo { get; set; }
            public int ActualTime { get; set; }
            public int LogWork { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime AssignedDate { get; set; }
            public DateTime ResolveDate { get; set; }
            public int EstimatedTime { get; set; }
        }
        public enum EnumTasks
        {
            
            User = 1,
            Project = 2,
            Priority = 3,
            TaskType = 4,
            Version = 5,
            Module = 6,
            Subject = 7,
            Details = 8,          
            Status = 9,            
            Assigned_By = 10,
            Assigned_To = 11,
            Created_Date = 12,
            Assigned_Date = 13,
            Resolve_Date = 14,
            Estimated_Time = 15,
            Actual_Time = 16,
            LogWork = 17
        }
        public IQueryable DynamicSelectionColumns()
        {
            using (var db = new TrackerDataContext())
            {
                string fieldIds = "," + "4,5,3,2,6,17,11,12" + ",";
                var taskColum = Enum.GetValues(typeof(EnumTasks)).Cast<EnumTasks>().Where(e => fieldIds.Contains("," + ((int)e).ToString() + ",")).Select(e => e.ToString().Replace("_", ""));
                string select = "new (  TaskId, " + (taskColum.Count() > 0 ? string.Join(", ", taskColum) + ", " : "") + "Id )";
                return db.Task.ToList().Select(t => new DynamicColumns() { Id = t.Id, TaskId = Project != null ? Project.Alias + "-" + t.Id : t.Id.ToString(), ActualTime = t.ActualTime, AssignedBy = t.AssignedBy.ToString(), AssignedDate = t.AssignedDate, AssignedTo = t.AssignedTo.ToString(), CreatedDate = t.CreatedDate, Details = t.Details, EstimatedTime = t.EstimatedTime, FileName = t.FileName, LogWork = t.LogWork, Module = t.Module != null ? t.Module.Name : "", Priority = t.Priority != null ? t.Priority.Name : "", Project = t.Project != null ? t.Project.Name : "", ResolveDate = t.ResolveDate, Status = t.Status != null ? t.Status.Name : "", Subject = t.Subject, TaskType = t.TaskType != null ? t.TaskType.Type : "", Version = t.Version != null ? t.Version.Name : "" }).ToList().AsQueryable().Select(select);
            }
        }
