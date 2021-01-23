         private IEnumerable<Func<string, bool>> _getFilterLabda(IDictionary<string, string> filters)
        {
            var invokeList = new List<Func<string, bool>>();
            invokeList.Add(surveyUserView=>surveyUserView.deleted != "deleted");
            if (filters.ContainsKey("RegionFilter"))
            {
                invokeList.Add(surveyUserView=>surveyUserView.Region == filters["RegionFilter"]);
            }
            if (filters.ContainsKey("LanguageFilter"))
            {
                invokeList.Add(surveyUserView=>surveyUserView.Locale == filters["LanguageFilter"]);
            }
            if (filters.ContainsKey("StatusFilter"))
            {
                invokeList.Add(surveyUserView=>surveyUserView.Status == filters["StatusFilter"]);
            }
            if (filters.ContainsKey("DepartmentFilter"))
            {
                invokeList.Add(surveyUserView=>surveyUserView.department == filters["DepartmentFilter"];
            }
            return invokeList;
        }
        ...
        bool result = _getFilterLabda(filters)
                      .Aggregate(true, (current, del) => current & del(suv));
