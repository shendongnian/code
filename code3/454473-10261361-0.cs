    public bool Login( string UserName, string Pwd )
    {
        // validate the user and create the forms cookie upon succesfull validaition
        if ( IsValid( UserName, Pwd ) ) 
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket( ... );
            string CookieName = FOrmsAuthentication.FormsCookieName;
            string CookieValue = ticket.Encrypt();
            this.Response.Cookies.Add( new HttpCookie( CookieName, CookieValue ) );
        }
    }
