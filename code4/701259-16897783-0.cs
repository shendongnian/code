    SvnUpdateResult result;
    SvnUpdateArgs args = new SvnUpdateArgs();
    // If args.Revision is not set, it defaults to fetch the HEAD revision.
    if (revision > 0)
    {
        args.Revision = revision;
    }
    // Perform the update
    using (SvnClient client = GetClient())
    {
        client.Update(localPath, args, out result);
    }
