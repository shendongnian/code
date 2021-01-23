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
 
        this.Literal1.Text = combineUrl.ToUrl();  // the result
*/
public class CombineUrl
{
    private System.Collections.Generic.List<string> m_Urls = new System.Collections.Generic.List<string>();
    public void Add(string url)
    {
        m_Urls.Add(url);
    }
    public string ToUrl()
    {
        string retVal = string.Empty;
        foreach (string url in m_Urls)
        {
            if (string.IsNullOrWhiteSpace(retVal))
            {
                retVal = url;
            }
            else
            {
                retVal = new System.Uri(new System.Uri(retVal + "/"), url).ToString();
            }
        }
        return retVal;
    }
}
</PRE>
