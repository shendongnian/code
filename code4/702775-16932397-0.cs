    public List<PersonModel> GetPeople(int owningOrganisationID, int skip, int records, out int totalCount, Ordering orderByDirection, string filter, string orderBy = "")
    {			
        if (string.IsNullOrEmpty(orderBy))
            orderBy = "PersonID";
        if (!string.IsNullOrEmpty(filter))
        {
            filter = filter.ToLower();
			//use a first query to take only the ids of the data that match the filter.
			List<int> peopleViewIds = Context.PeopleView.Where(p => p.OwningOrganisationID == owningOrganisationID &&
                p.City.ToLower().Contains(filter)
                || p.CountryName.ToLower().Contains(filter)
                || p.Forename.ToLower().Contains(filter)
                || p.PersonTypeName.ToLower().Contains(filter)
                || p.Postcode.ToLower().Contains(filter)
                || p.Surname.ToLower().Contains(filter))
				.OrderBy(orderBy + " " + orderByDirection.ToString())
				.Select(p => p.Id).ToList();
				
			//set the out parameter to the total count of the retrieved ids
			totalCount = peopleViewIds.Count;
			
			if(totalCount > 0){			
				//page the ids accordingly (the sorting of the ids was applied in the previous query)
				List<int> pagedPeopleViewIds = peopleViewIds.Skip(skip).Take(records).ToList();
	
				//use the paged ids to make a second query, this time only with the required ids. This should be really fast if you have PersonModel.Id is a PRIMARY KEY or you have an index attached on this column
				return Context.PeopleView.Where(p => pagedPeopleViewIds.Contains(p.Id))
						.OrderBy(orderBy + " " + orderByDirection.ToString())                    
						.ToList();
			}
			else {
				//no results, return an empty list
				return new List<PersonModel>();
			}
        }
        else
        {
            totalCount = Context.PeopleView.Where(p => p.OwningOrganisationID == owningOrganisationID).Count();
            return Context.PeopleView
                .Where(o => o.OwningOrganisationID == owningOrganisationID)
                .OrderBy(orderBy + " " + orderByDirection.ToString())
                .Skip(skip)
                .Take(records)
                .ToList();
        }
    }
