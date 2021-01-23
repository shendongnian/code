    // Retrieve all versions
    SPListItemVersionCollection itemVersions = item.Versions;
    for (int i = 0; i < itemVersions.Count - 1; i++)
    {
	    // Check if version is published
        if (itemVersions[i].Level == SPFileLevel.Published)
		{
			return itemVersions[i];
		}
    }
