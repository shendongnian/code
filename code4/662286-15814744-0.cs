    public void writeCookie(string name, string value) {
            if(Response.Cookies["MyApp"] == null) {
                HttpCookie newCookie = new HttpCookie("MyApp");
                newCookie.Expires = DateTime.Now.AddYears(1);
                Response.SetCookie(newCookie);
            }
            if(Response.Cookies["MyApp"][name] == null)
                Response.Cookies["MyApp"].Values.Add(name, value);
            else
                Response.Cookies["MyApp"][name] = val;
           // or maybe simple                 Response.Cookies["MyApp"][name] = val; will work fine, not sure here
        }
