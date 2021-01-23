     IEnumerable<App_ProjectTask> temp;
    if (!String.IsNullOrEmpty(query))
    {
    temp = dc.App_ProjectTasks.Where(x => x.Title.ToLower().Contains(query.ToLower()) || x.Description.ToLower().Contains(query.ToLower()));
    if (temp.Count() > 0)
    {
        results = temp.ToList();
    }
    }
