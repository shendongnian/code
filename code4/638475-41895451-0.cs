    private static FormsAuthenticationTicket GetLatestCookie(HttpCookieCollection cookies, string cookieName) {
	var cookieOccurrences = new List<FormsAuthenticationTicket>();
	for (int index = 0; index < cookies.Count; index++) {
		if (cookies.GetKey(index) == cookieName) {
			FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookies[index].Value);
			cookieOccurrences.Add(ticket);
		}
	}
	DateTime oldestTime = DateTime.MinValue;
	FormsAuthenticationTicket oldestTicket = null;
	foreach (var formsAuthenticationTicket in cookieOccurrences) {
		if (formsAuthenticationTicket.Expiration > oldestTime) {
			oldestTime = formsAuthenticationTicket.Expiration;
			oldestTicket = formsAuthenticationTicket;
		}
	}
	return oldestTicket;
}
