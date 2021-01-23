csharp
public static class UriExtensions
{
    private static readonly Regex LastSegmentPattern = 
        new Regex(@"([^:]+://[^?]+)(/[^/?#]+)(.*$)", RegexOptions.Compiled | RegexOptions.IgnoreCase);        
    public static Uri ReplaceLastSegement(this Uri me, string replacement)
        => me != null ? new Uri(LastSegmentPattern.Replace(me.AbsoluteUri, $"$1/{replacement}$3")) : null;
    public static Uri RemoveLastSegement(this Uri me)
        => me != null ? new Uri(LastSegmentPattern.Replace(me.AbsoluteUri, "$1$3")) : null;
}
