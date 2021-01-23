    Expression<Func<PersonalInfo, bool>> filterExperssion = PredicateExtensions.True<PersonalInfo>();
                   
                if (!String.IsNullOrEmpty(firstName))
                    filterExperssion = filterExperssion.And(p => p.FirstName == firstName);
                if (!String.IsNullOrEmpty(lastName))
                    ......
               
