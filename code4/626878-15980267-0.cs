    Helper.ProjectTimeLine.webControl.DocumentReady += (object s, UrlEventArgs ee) =>
    {
        Helper.ProjectTimeLine.webControl.ExecuteJavascript("window.source = " + DynamicJson.Serialize(source));
        Helper.ProjectTimeLine.webControl.ExecuteJavascript("start();");
    };
