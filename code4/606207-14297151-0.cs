	public string[] getCollectionNames()
			{
				using (var session = this.store.OpenSession())
				{
					return session.Advanced.LuceneQuery<dynamic>()
							   .SelectFields<dynamic>("@metadata")
							   .Select<dynamic, string>(x => x["@metadata"]["Raven-Entity-Name"])
							   .Distinct()
							   .ToArray();
							
				}
			}
