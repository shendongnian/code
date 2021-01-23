    var memberGroups = child.Properties["memberOf"].Value;
    if (memberGroups.GetType() == typeof(string))
    {
        row["Groups"] = (String)memberGroups;
    }
    else if (memberGroups.GetType().IsArray)
    {
        var memberGroupsEnumerable = memberGroups as IEnumerable;
        if (memberGroupsEnumerable != null)
        {
            var asStringEnumerable = memberGroupsEnumerable.OfType<object>().Select(obj => obj.ToString());
            row["Groups"] = String.Join(", ", asStringEnumerable);
        }
    }
    else
    {
        row["Groups"] = "No group found.";
    }
