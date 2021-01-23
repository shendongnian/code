    CallContext.LogicalSetData("CurrentSession", Session);
    var getreginfoThread = new Thread(
        () =>
        {
            string sCarmodel;
            GetRegInfo gri = new GetRegInfo(reg, out sCarmodel);
            var session = (HttpSessionState)CallContext.LogicalGetData("CurrentSession");
            session["test"] = sCarmodel;
        }
        );
    getreginfoThread.Start();
    return View("Check");
