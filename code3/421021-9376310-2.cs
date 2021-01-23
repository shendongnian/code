    public class YouMembershipProvider: MembershipProvider
    {
    public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
    {
         var appName = config["applicationName"];
    }
