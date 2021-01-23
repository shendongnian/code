        public ValidationResult DoSomeAction(RequestFilters filters)
        {
            var ret = new ValidationResult();
            if (filters.SomeProp1 == null) ret.AddEmptyFieldError(nameof(filters.SomeProp1));
            if (filters.SomeOtherProp2 == null) ret.AddFieldError(nameof(filters.SomeOtherProp2 ), $"Failed to parse {filters.SomeOtherProp2} into integer list");
            if (filters.MinProp == null) ret.AddEmptyFieldError(nameof(filters.MinProp));
            if (filters.MaxProp == null) ret.AddEmptyFieldError(nameof(filters.MaxProp));
            // validation affecting multiple input parameters
            if (filters.MinProp > filters.MaxProp)
            {
                ret.AddFieldError(nameof(filters.MinProp, "Min prop cannot be greater than max prop"));
                ret.AddFieldError(nameof(filters.MaxProp, "Check"));
            }
            // also specify a global error message, if we have at least one error
            if (ret.IsError)
            {
                ret.Message = "Failed to perform DoSomeAction";
                return ret;
            }
            ret.Message = "Successfully performed DoSomeAction";
            return ret;
        }
