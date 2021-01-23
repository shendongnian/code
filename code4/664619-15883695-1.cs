        SessionImages ImageModel = new SessionImages
        {
            Name = Request.Files[i].FileName,
            Path = Path.Combine("~/Photos/Sessions/", SessionModel.Name, "actual", Request.Files[i].FileName),
            //Session = SessionModel,
            SessionID = SessionID
        };
