    if (chBox.Checked)
    
          {
              HttpCookie myCookie = new HttpCookie("Cookie_Remember"); //new cookie object
    
              Response.Cookies.Remove("Cookie_Remember"); //This will remove previous cookie
              Response.Cookies.Add(Cookie_Remember); //This will create new cookie
    
              Cookie_Remember.Values.Add("UserInfo", txt_username.Text); //Add User Name 
    
            // You can add multiple values
    
              DateTime CookieExpir= DateTime.Now.AddDays(5); //Cookie life
    
              Response.Cookies["Cookie_Remember"].Expires = CookieExpir; //Maximum day of cookie's life       
          }
