    int[] xs = { 2, 3, 5, 8, 13 };
    var c = new SqlCommand();
    var parameters = xs.Select((x, i) => string.Concat("@xs", i)).ToList();
    for (var i = 0; i < xs.Count; i++)
    {
        c.Parameters.AddWithValue(parameters[i], xs[i]);
    }
    c.CommandText = string.Format(
        "SELECT ... FROM ... WHERE ... IN ({0})", 
        string.Join(", ", parameters)
    );
