    int id = 1;
    Type type = typeof(TaskType);
    BindingFlags privateInstance = BindingFlags.NonPublic | BindingFlags.Instance;
    var name = type
        .GetFields(BindingFlags.Public | BindingFlags.Static)
        .Select(p => p.GetValue(null))
        .Cast<TaskType>()
        .Where(t => (int)type.GetField("value", privateInstance).GetValue(t) == id)
        .Select(t => (string)type.GetField("name", privateInstance).GetValue(t))
        .FirstOrDefault();
    // Output: Bug
