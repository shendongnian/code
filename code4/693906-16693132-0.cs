    List<int> testId = ...;
    var sb = new StringBuilder();
    sb.Append("DELETE FROM TEST WHERE TESTID IN (");
    bool first = true;
    foreach (var i in testId)
    {
        if (first)
            first = false;
        else
            sb.Append(",");
        sb.Append(i.ToString(CultureInfo.InvariantCulture));
    }
    sb.Append(")");
    Context.Database.ExecuteSqlCommand(sb.ToString());
