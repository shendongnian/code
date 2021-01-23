    foreach (System.Web.UI.Control cntrl in pControl.TabPages[1].Controls)
    {
        if (cntrl is ASPxTextBox)
        {
           VALUES += string.Format("'{0}' + ",", (cntrl as ASPxTextBox).Text);
        }
    }</code></pre>
If when doing this you still don't get the text property value, there might be a problem with the internals of the control and is not capturing the entered text in the browser when the page goes through the LoadPostData stage.
Also something you need to be aware of is that for this LoadPostData to be successful when adding controls using ASP.NET AJAX is that you need to load this control on the page for every postback after you create them to be able to get the values back.
Hope this helps.
