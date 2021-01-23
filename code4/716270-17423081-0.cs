            var inputtextbox = browser.TextField(Find.ByName("CASE"));
            if (!inputtextbox.Exists)
            {
                LogError(c, fileNumber, CommonUtils.Messages.ElementNotFound, ClientID);
                return;
            }
