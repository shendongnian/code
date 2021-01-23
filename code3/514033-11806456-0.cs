private void OnAuthenticate(object sender, AuthenticateEventArgs e)
{
    bool Authenticated = false;
    Authenticated = SiteSpecificAuthenticationMethod(Login1.UserName, Login1.Password);
    e.Authenticated = Authenticated;
}
implement SiteSpecificAuthenticationMethod that will validate user against database.
