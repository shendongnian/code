        class CompositeFilter {
            bool IsANDCondition; // if false, it is OR;
            List<IFilter> childFilters;
            bool Evaluate(XElement element) {
                bool result = IsANDCondition;
                foreach (var filter in childFilters)
                {
                    bool b = filter.Evaluate(element);
                    if (IsANDCondition)
                        result = b && result;
                    else
                        result = b || result;
                }
                return result;
            }
        }
    
