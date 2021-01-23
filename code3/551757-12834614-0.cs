    var tasksFromQueue = DetachedCriteria.For<Task>()
        .Add(Restriction.Or(
            Subqueries.In("SiteID", DetachedCriteria.For<QueueLocation>().Add(Restrictions.Eq("Queue.ID", queueID)).SetProjection(Projection.Property("ComponentID")),
            Subqueries.In("OriginalSiteID", DetachedCriteria.For<QueueLocation>().Add(Restrictions.Eq("Queue.ID", queueID)).SetProjection(Projection.Property("ComponentID")))
        .SetProjection(Projection.Id());
    
        "Select t from Task t, QueueLocation q where q.Queue.ID = :queueID and (t.SiteID = q.ComponentID or t.OriginalSiteID = q.ComponentID)")
        .SetParameter("queueID", queueID).List<Task>().ToList();
    
    var tasksFromWorkflow = DetachedCriteria.For<Task>()
        .CreateAlias("Order", "order")
        .CreateAlias("TaskDevice", "device")
        .Add(<restrictions>)
        .SetProjection(Projections.Id());
    
    var results = NHibernateSession.CreateCriteria<Task>()
        .Add(Subqueries.In("Id", tasksFromQueue))
        .Add(Subqueries.In("Id", tasksFromWorkflow))
        .List<Task>();
