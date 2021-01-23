    var twoWeeksTime = DateTime.Now.AddDays(14);
    var subquery = NHibernate.Criterion.QueryOver.Of<ToDo>().Select(t => t.TaskName);
    var matchingItems = Session.QueryOver<WorkshopItem>()
                               .Where(w => w.DateDue <= twoWeeksTime && 
                                           w.IsWorkshopItemInProgress == true)
                               .WithSubquery.WhereProperty(x => x.Name).NotIn(subquery)
                               .Future<WorkshopItem>();
