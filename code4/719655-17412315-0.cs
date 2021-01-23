    if (!this.IsPostBack) { Session["RetryCount"] = 1; }
    else
    {
        int retryCount = (int)Session["RetryCount"];
        if (retryCount == 3) { // do something because it's bad }
        else { retryCount++; Session["RetryCount"] = retryCount; }
    }
