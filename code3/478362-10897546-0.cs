        private static void InvokeMethod(Action<SiteOperation> action)
        {
            foreach (SiteOperation siteOperation in _sitesManagement.GetAll()
                                   .Select(site=>new SiteOperation(site))
            {
                action(siteOperation);
            }
        }
    ..
        public static void KillJames()
        {
            InvokeMethod(so => so.KillJames());
        }
        public static void LimitBandwidth(int wantedBandwidthInLBps)
        {
            InvokeMethod(so => so.LimitBandwidth(wantedBandwidthInLBps));
        }
        public static void FlyToMoon(int year=2012, TaskIdentifier ti=new TaskIdentifier(10,20))
        {
            InvokeMethod(so => so.FlyToMoon(year, ti));
        }
