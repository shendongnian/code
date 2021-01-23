    //tested on SharpSVN 1.8009.3299.43
    SvnListArgs arg = new SvnListArgs();
    arg.Revision = new SvnRevision(2); //the revision you want to check
    arg.RetrieveEntries = SvnDirEntryItems.Size;
    client.GetList(target, arg, out list);
    long sizeInBytes = list[0].Entry.FileSize;
