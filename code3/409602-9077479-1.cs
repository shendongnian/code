        for (int i = 0; i < limit; i++)
        {
            cookieName = Request.Cookies[i].Name;
            if (cookieName == "username")
            {
                aCookie = new HttpCookie(cookieName);
                aCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(aCookie);
            }
        }
