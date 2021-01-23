    if (reader.ReadToFollowing("platforms"))
    {
        while (reader.Read())
        {
            if (string.Compare(reader.Name, "platforms") == 0)
                break;
            if ((string.Compare(reader.Name, "name") == 0))
            {
                string s = reader.ReadElementContentAsString();
                gPlat = gPlat + s + Environment.NewLine;
            }
        }
    }
