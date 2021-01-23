        private IEnumerable<Func<SurveyUserView, bool>> _getFilterLabda(IDictionary<string, string> filters)
        {
            var invokeList = new List<Func<string, bool>>();
            invokeList.Add(surveyUserView=>surveyUserView.deleted != "deleted");
            if (filters.ContainsKey("RegionFilter"))
            {
                invokeList.Add(delegate(SurveyUserView surveyUserView)
                {
                    return surveyUserView.Region == filters["RegionFilter"];
                });
            }
            if (filters.ContainsKey("LanguageFilter"))
            {
                invokeList.Add(delegate(SurveyUserView surveyUserView)
                {
                    return surveyUserView.Locale == filters["LanguageFilter"];
                });
            }
            if (filters.ContainsKey("StatusFilter"))
            {
                invokeList.Add(delegate(SurveyUserView surveyUserView)
                {
                    return surveyUserView.Status == filters["StatusFilter"];
                });
            }
            if (filters.ContainsKey("DepartmentFilter"))
            {
                invokeList.Add(delegate(SurveyUserView surveyUserView)
                {
                    return surveyUserView.department == filters["DepartmentFilter"];
                });
            }
            return invokeList;
        }
        ...
        Func<SurveyUserView, bool> resultFilter = suv => _getFilterLabda(filters)
                   .Aggregate(true, (current, del) => current & del(suv));
