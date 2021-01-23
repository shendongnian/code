    class AssociateioniMapper : UriMapperBase
    {
    public override Uri MapUri(Uri uri)
    {
        tempUri = System.Net.HttpUtility.UrlDecode(uri.ToString());
        Uri retUri = uri;
        //handle known uri schemes
        if (uriUsesKnownScheme(uri))
        { 
            Debug.WriteLine("Known Uri scheme: " + uri.Scheme);
            NavigateConsideringKnownScheme(uri);
            retUri = null;
        }
    }
    private bool uriUsesKnownScheme(Uri uri)
    {
            try
            {
                switch (uri.Scheme)
                {
                    case "http":
                    case "https":
                    case "mailto":
                    case "tel":
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception)
            {
                //uri does not have a scheme
                return false;
            }
    } 
    private void NavigateConsideringKnownScheme(Uri uri)
        {
            try
            {
                switch (uri.Scheme)
                {
                    case schemeHttp:
                    case schemeHttps:
                        //open URI in IE
                        WebBrowserTask webBrowserTask = new WebBrowserTask();
                        webBrowserTask.Uri = uri;
                        webBrowserTask.Show();
                        break;
                    case schemeMailto:
                        //initiate eMail task
                        if (! string.IsNullOrWhiteSpace(uri.Query))
                            handleMailtoUrl_Query(uri.Query);
                        else
                            handleMailtoUrl_To(uri.OriginalString.Replace("mailto:", string.Empty));
                        break;
                    case schemeTel:
                        //initiate phonecall task
                        handleTel(uri.PathAndQuery);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }   
        private void handleTel(string parameter)
        {
            try
            {
                string p = parameter as string;
                string number = p;
                string displayName = string.Empty;
                number = Regex.Replace(number, "[^+0-9]", "");
                startPhoneCall(number, displayName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void startPhoneCall(string number, string displayName)
        {
            try
            {
                PhoneCallTask phoneCallTask = new PhoneCallTask();
                phoneCallTask.PhoneNumber = number;
                if (!string.IsNullOrWhiteSpace(displayName))
                {
                    phoneCallTask.DisplayName = displayName;
                }
                phoneCallTask.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show(LocalizationHelper.GetString("ContactPhonecallError"));
            }
        }
        private void handleMailtoUrl_Query(string query)
        {
           //handle subject, to, body and other parameters if required
        }
        private void handleMailtoUrl_To(string to)
        {
            try
            {
                EmailComposeTask emailComposeTask = new EmailComposeTask();
                emailComposeTask.To = to;
                emailComposeTask.Show();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
