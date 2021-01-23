    sqlsource.SelectCommand = "SELECT x from x where this_id LIKE '%" + SanitizedString(txtBox.Text) + "%';";
    // ... codes ...
    private string SanitizedString(string given)
    {
       string sanitized = given.Replace(";", string.Empty);
       sanitized = sanitized.Replace("--", string.Empty);
       // ... ad nauseum, conditions galore ...
       return sanitized;
    }
