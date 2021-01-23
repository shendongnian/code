    public static TaskType GetTaskType(int id)
    {
        FieldInfo[] fields = typeof(TaskType).GetFields(BindingFlags.Public | BindingFlags.Static);
        foreach (FieldInfo field in fields)
        {
            TaskType t = (TaskType)field.GetValue(null);
            if (t.value == id)
            {
                return t;
            }
        }
        return null;
    }
