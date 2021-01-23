    var duplicateGroups = files.GroupBy(file => file.Name)
                               .Where(group => group.Count() > 1);
    // Replace with what you want to do
    foreach (var group in duplicateGroups)
    {
         Console.WriteLine("Files with name {0}", group.Key);
         foreach (var file in group)
         {
             Console.WriteLine("  {0}", file.FullName);
         }
    }
