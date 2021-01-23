    public void DeleteTask()
    {
        NHibernateSessionManager.Instance.BeginTransaction();
        Task.Order.Tasks.Remove(Task);
        NHibernateSessionManager.Instance.CommitTransaction();
    }
