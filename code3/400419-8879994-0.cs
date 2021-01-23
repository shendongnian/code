        foreach (PropertyCriteria criteria in criterias)
        {
          if (criteria.IsNull)
          {
            criteria.Value = null;
          }
          else if (string.IsNullOrEmpty(criteria.Value))
          {
            throw new EPiServerException("The crieria value cannot be null or empty. Set the IsNull property to search for null.");
          }
          ...
        }
