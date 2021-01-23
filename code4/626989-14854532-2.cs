    public void Execute(string query, Action<Dictionary<string, object>> parameterizer)
    
    Execute(query, p =>
        {
            p["user_id"] = 1;
            p["mf"] = "6CE71037";
        });
