            var predicate = PredicateBuilder.True<SurveyResult>();
            
            IEnumerable<SurveyResult> a;
            if (excludeBadData)
            
            if (firstName != string.Empty)
            {
                predicate = predicate.And(p => p.User.FirstName.ToLower().Contains(firstName.ToLower()));
            }
            if (lastName != string.Empty)
            {
                predicate = predicate.And(p => p.User.LastName.ToLower().Contains(lastName.ToLower()));
            }
           
            a = from r in results.AsQueryable().Where(predicate) select r;
            return a;
        }
