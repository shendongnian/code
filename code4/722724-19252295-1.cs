    public Task<JsonResult> CheckForOnline(Int64? adId)
        {
            ITaskRunner taskRunner = IoCFactory.Instance.TryResolve<ITaskRunner>();
            return taskRunner.Execute(() => CheckForOnlineFunc(adId),
                r => Json(r.Result, JsonRequestBehavior.AllowGet));
        }
