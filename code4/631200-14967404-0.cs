    public IDictionary<string, ICollection<ValueSet>> GetValueSets(
        ICollection<ValueSet> contentSetGuids)
    {
        var dic = new Dictionary<string, ICollection<ValueSet>>();
        using (SqlCommand command = new SqlCommand())
        {
            // ...
            dic = GetObjects(command)
			      .GroupBy(vs => vs.ContentSetGuid)
				  .ToDictionary(grp => grp.Key, grp => grp.ToList());
        }
        return dic;
    }
