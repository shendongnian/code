    var subquery = QueryOver.Of<DismissedNoticeToUser>()
							.Where(x => x.UserId == userId)
							.Select(x => x.NoticeId);
						  
	IList<Notice> noticesFound = session.QueryOver<Notice>()
								   .WithSubquery.WhereProperty(x => x.Id).NotIn(subquery)
								   .List<Notice>();
