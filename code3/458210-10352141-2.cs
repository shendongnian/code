    private void MyWrapperCall(string url, string expectedTitle, Action<MyRequestState> callback)
    {
        Action<MyRequestState> redirectCallback = null;
        redirectCallback = new Action<MyRequestState>((state) =>
        {
            if(state.DoRedirect)
            {
                DoWebRequest(state.Redirect, expectedTitle, redirectCallback);
            }
            else
            {
                callback(state);
            }
        });
        DoWebRequest(url, expectedTitle, redirectCallback);
    }
