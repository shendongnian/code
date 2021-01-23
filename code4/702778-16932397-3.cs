    public List<PersonModel> GetPeople(int owningOrganisationID, int skip, int records, out int totalCount, Ordering orderByDirection, string filter, string orderBy = "") {
            List<PersonModel> result = new List<PersonModel>();
            if (string.IsNullOrEmpty(orderBy)) {
                orderBy = "PersonID";
            }
            if (!string.IsNullOrWhiteSpace(filter)) {
                filter = filter.ToLower();
            }
            //use a first query to take only the ids of the data that match the filter.
            List<int> peopleViewIds = Context.PeopleView
                .Where(p => p.OwningOrganisationID == owningOrganisationID)
                .WithFiltering(filter) //use our extension here!!!
                .OrderBy(orderBy + " " + orderByDirection.ToString())
                .Select(p => p.Id).ToList();
            //set the 'out' parameter to the total count of the retrieved ids
            totalCount = peopleViewIds.Count;
            if (totalCount > 0) {
                //page the ids accordingly (the sorting of the ids was applied in the previous query)
                List<int> pagedPeopleViewIds = peopleViewIds.Skip(skip).Take(records).ToList();
                //use the paged ids to make a second query, this time only with the required ids. 
                //This should be really fast if you have PersonModel.Id is a PRIMARY KEY or you have an index attached on this column
                //Please note the reuse of the OrderBy, this will ensure the correct order on the paged result
                result = Context.PeopleView.Where(p => pagedPeopleViewIds.Contains(p.Id))
                    .OrderBy(orderBy + " " + orderByDirection.ToString())                    
                    .ToList();
            }
            return result;
        }
