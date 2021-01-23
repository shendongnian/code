    public class ReportServerCredentials : IReportServerCredentials
    {
    private string _UserName;
    private string _PassWord;
    private string _DomainName;
    public ReportServerCredentials(string UserName, string PassWord, string DomainName)
    {
        _UserName = UserName;
        _PassWord = PassWord;
        _DomainName = DomainName;
    }
    public System.Security.Principal.WindowsIdentity ImpersonationUser
    {
        // use default identity
        get { return null; }
    }
    public ICredentials NetworkCredentials
    {
        // use default identity
        get { return new NetworkCredential(_UserName, _PassWord, _DomainName); }
    }
    public bool GetFormsCredentials(out Cookie authCookie, out string user,
     out string password, out string authority)
    {
        authCookie = null;
        user = password = authority = null;
        return false;
    }
    }
