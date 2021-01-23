    public List<TaskObject> GetAssignedTasks(int personId)
        {
            var items = (from s in _te.tasks.Include("Person") where s.person.person_id == personId select s).ToList();
            var tasks = new List<TaskObject>();
            foreach (var t in items)
            {
    
                TaskObject tk = Transformer.UnpackTask(t);
    
                tasks.Add(tk);
            }
            return tasks;
        }
