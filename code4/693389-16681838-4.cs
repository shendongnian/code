    var options = RegexOptions.Compiled | RegexOptions.IgnoreCase;
    string compilableExpression = "Regex.IsMatch(Category.ToLower(), \"\\bSomeCat\\b\", @0) == true";
    ParameterExpression parameter1 = SLE.Expression.Parameter(typeof(EventListItem));
    return SLD.DynamicExpression.ParseLambda(new[] { parameter1 },
                                             null,
                                             compilableExpression,
                                             options);
