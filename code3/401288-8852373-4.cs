    if (WeAreInSearchGroup())
    {
        if (WeAreDeletingAllSires())
        {
            deletedSire = new ArrayList();
            deletedSire.AddRange( sireGroupBE.SireList);
        }
        else
        {
            deletedSire = GetDeleteSire(sireGroupBE.SireList);
        }
    }
