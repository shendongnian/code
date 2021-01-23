<PRE>
I have a class that I use for this purpose:
/*
 A tiny class to combine urls like System.IO.Path.Combine
 Usage example:
        var combineUrl = new CombineUrl();
        combineUrl.Add("http://stackoverflow.com");
        combineUrl.Add("questions"); 
        combineUrl.Add("372865"); 
        combineUrl.Add("path-combine-for-urls");
 
        Literal1.Text = combineUrl.ToUrl();  // the result
*/
public class CombineUrl
{
    public void Add(string url)
    {
        m_Urls.Add(url.Trim().TrimEnd('/').TrimStart('/').Trim());
    }
    public string ToUrl()
    {
        string retVal = string.Empty;
        foreach (string url in m_Urls)
        {
            retVal = string.IsNullOrWhiteSpace(retVal) ? url : new System.Uri(new System.Uri(retVal + "/"), url).ToString();
        }
        return retVal;
    }
    // Class variable
    private System.Collections.Generic.List<string> m_Urls = new System.Collections.Generic.List<string>();
}
</PRE>
