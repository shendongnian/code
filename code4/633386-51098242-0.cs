        public ActionResult DisplayUserInfo(string userName)
        {
            // trick to prevent deadlocks of calling async method 
            // and waiting for on a sync UI thread.
            var syncContext = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(null);
            //  this is the async call, wait for the result (!)
            var model = _asyncService.GetUserInfo(Username).Result;
            // restore the context
            SynchronizationContext.SetSynchronizationContext(syncContext);
            return PartialView("_UserInfo", model);
        }
