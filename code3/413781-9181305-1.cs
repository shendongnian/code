		public IEnumerable<ValidationResult> ValidateQuery(Query query)
		{
			if (!ValidateColumns(query)) yield return new ValidationResult("Bad columns");
			if (!ValidateFilters(query)) yield return new ValidationResult("Bad filters");
			if (!ValidateGroups(query)) yield return new ValidationResult("Bad groups");
			if (!ValidateSortOrders(query)) yield return new ValidationResult("Bad sort order");
		}
