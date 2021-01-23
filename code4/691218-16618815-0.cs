    int ordinalPos = reader.GetOrdinal("Comments");
    if(!reader.IsDBNull(ordinalPos))
    {
        labelComment.Text = reader.GetString(ordinalPos);
    }
    else
    {
        labelComment.Text = "No comments found!";
    }
