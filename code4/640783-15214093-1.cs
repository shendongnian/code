    public static TaskType GetTaskType(int id)
    {
        return typeof(TaskType)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(f => (f.GetValue(null) as TaskType))
            .FirstOrDefault(t => t != null && t.value == id);
    }
    public static TaskType GetTaskType(string name)
    {
        return typeof(TaskType)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(f => (f.GetValue(null) as TaskType))
            .FirstOrDefault(
                t => t != null &&
                t.name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
    }
