    StringBuilder builder = new StringBuilder();
    for(var item in db.IconTags) {
        builder.Append(item.Tag).Append(",");
    }
    // We have one extraneous , so remove it
    if(builder.Length > 1) {
        builder.Remove(builder.Length - 1, 1);
    }
    String output = builder.ToString();
