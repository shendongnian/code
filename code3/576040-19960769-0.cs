    using System.Configuration;
    using System.Net.Configuration;
    // snip...
    var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
    string username = smtpSection.Network.UserName;
