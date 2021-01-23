    using (SvnClient cl = new SvnClient())
      cl.Status(YourPath, new SvnStatusArgs {
        Depth = SvnDepth.Infinity, ThrowOnError = true,
        RetrieveRemoteStatus = true, Revision = SvnRevision.Head}, 
        new EventHandler<SvnStatusEventArgs>(
           delegate(object s, SvnStatusEventArgs e) {
              switch (e.LocalContentStatus) {
                 case SvnStatus.Normal:break;
                 case SvnStatus.None: break;
                 case SvnStatus.NotVersioned: break;
                 case SvnStatus.Added:break;
                 case SvnStatus.Missing: break;
                 case SvnStatus.Modified: break;
                 case SvnStatus.Conflicted: break;
                 default: break;
              }
              switch (e.RemoteContentStatus) {
                 case SvnStatus.Normal:break;
                 case SvnStatus.None: break;
                 case SvnStatus.NotVersioned: break;
                 case SvnStatus.Added:break;
                 case SvnStatus.Missing: break;
                 case SvnStatus.Modified: break;
                 case SvnStatus.Conflicted: break;
                 default: break;
              }
           }));
