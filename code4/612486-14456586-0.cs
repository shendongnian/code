    DateTime parsed;
    if (DateTime.TryParse(text, out parsed))
    {
        string reformatted = parsed.ToString("yyyy-MM-dd");
        // Use reformatted
    }
    else
    {
        // Log error, perhaps?
    }
