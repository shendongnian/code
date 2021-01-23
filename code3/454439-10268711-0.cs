		/// <summary>
		/// Searches the logs for matching records
		/// </summary>
		/// <param name="fromUTC">Start point timestamp of the search</param>
		/// <param name="toUTC">End point timestamp of the search</param>
		/// <param name="ofSeverity">Severity level of the log entry</param>
		/// <param name="orHigher">Retrieve more severe log entries as well that match</param>
		/// <param name="sourceStartsWith">The source field starts with these characters</param>
		/// <param name="usernameStartsWith">The username field starts with these characters</param>
		/// <param name="maxRecords">The maximum number of records to return</param>
		/// <returns>A list of Log objects with attached UserProfile objects</returns>
		public IEnumerable<Log> SearchLogs(
			DateTime fromUTC,
			DateTime toUTC,
			string ofSeverity,
			bool orHigher,
			string sourceStartsWith,
			string usernameStartsWith,
			int maxRecords)
		{
			ofSeverity = ofSeverity ?? "INFO";
			var query = DetachedCriteria.For<Log>()
				.SetFetchMode("UserProfile", NHibernate.FetchMode.Eager)
				.Add(Restrictions.In("Severity", (orHigher ?
					Translator.SeverityOrHigher(ofSeverity) : Translator.Severity(ofSeverity)).ToArray()))
				.Add(Restrictions.Between("TimeStamp", fromUTC, toUTC))
				.AddOrder(Order.Desc("TimeStamp"))
				.SetMaxResults(maxRecords);
			if (!string.IsNullOrEmpty(usernameStartsWith))
			{
				query.CreateCriteria("UserProfile")
					.Add(Restrictions.InsensitiveLike("UserName",
					usernameStartsWith, MatchMode.Start));
			}
			if (!string.IsNullOrEmpty(sourceStartsWith))
			{
				query
					.Add(Restrictions.InsensitiveLike("Source", sourceStartsWith, MatchMode.Start));
			}
			return query.GetExecutableCriteria(_Session).List<Log>();
		}
