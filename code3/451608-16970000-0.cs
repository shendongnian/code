    HttpCookie EncryptedCookie = Response.Cookies.Get(FormsAuthentication.FormsCookieName);
    FormsAuthenticationTicket DecryptedCookie;
    try {
        DecryptedCookie = FormsAuthentication.Decrypt(EncryptedCookie.Value);
    } catch (ArgumentException) {
        // Not a valid cookie
        return false;
    }
    // DecryptedCookie.Name: The Username
    // DecryptedCookie.UserData: Any additional data, as a string. This isn't normally used
    return !DecryptedCookie.Expired;
