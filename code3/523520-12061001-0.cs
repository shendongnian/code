	using (var session = GetSession())
	{
		//I honestly hope I never have to reverse engineer this mess.  Pagination in NHibernate
		//when ordering by an additional column is a nightmare.
		var countC = countCriteria.GetExecutableCriteria(session)
			.SetProjection(Projections.CountDistinct("RecordId"));
		var contentOrdered = contentCriteria
			.SetProjection(Projections.Distinct(
				Projections.ProjectionList()
					.Add(Projections.Id())
					.Add(Projections.Property("PersistedTimeStamp"))
					))
			.AddOrder(Order.Desc("PersistedTimeStamp"))
			.SetFirstResult((model.CurrentPage * model.ItemsPerPage) - model.ItemsPerPage)
			.SetMaxResults(model.ItemsPerPage);
		var contentIds = contentOrdered.GetExecutableCriteria(session)
			.List().OfType<IEnumerable<object>>()
			.Select(s => (Guid)s.First())
			.ToList();
		var contentC = DetachedCriteria.For<InvoiceItem>()
			.Add(Restrictions.In("RecordId", contentIds))
			.SetResultTransformer(Transformers.DistinctRootEntity);
		var mq = session.CreateMultiCriteria()
			.Add("total", countC)
			.Add("paged", contentC);
		model.Invoices = (mq.GetResult("paged") as System.Collections.ArrayList)
			.OfType<InvoiceItem>()
			.OrderBy(x => x.PersistedTimeStamp);
		model.TotalItems = (int)(mq.GetResult("total") as System.Collections.ArrayList)[0];
	}
	return model;
