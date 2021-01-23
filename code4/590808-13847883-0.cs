    StringBuilder sb = new StringBuilder();
    bool isFirst = true;
    foreach (var result in place)
    {
        if (!isFirst)
        {
            sb.Append(",");
        }
        isFirst = false;
        
        //Add the item data
        sb.AppendFormat("['{0}', {1}, {2}]", result.locName, result.Coord1, result.Coord2);
    }
    locations.Text = sb.ToString();
