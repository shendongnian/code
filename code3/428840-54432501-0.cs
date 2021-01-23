			var query = DbSession.Query<Site_IndexModel, Site_ForList>();
			List<FacetValue> facetResults = (await query
													.AggregateBy(builder => builder.ByField(s => s.CityCode ))
													.ExecuteAsync()
											).Single().Value.Values;
			// Go through results, where each facetResult is { Range, Count } structure for each stage ID
			return from result in facetResults
			select new { CityCode = result.Range, Count = result.Count }
