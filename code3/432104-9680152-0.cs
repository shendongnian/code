            var exp_details = new Predicate<tbl>(r =>
            {
                bool result == Id && r.Year == Year && r.Month == Month;
                if(IsDeleted != null)
                {
                    result &= r.IsDeleted == IsDeleted;
                }
                return result;
            });
