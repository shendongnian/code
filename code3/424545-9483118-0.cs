    void Delete(Task task)
    {
        foreach (var parent in task.Parents)
        {
            parent.Childs.Remove(task);
        }
        session.Delete(task);
    }
