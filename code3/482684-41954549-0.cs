        HttpCookie userInfo = new HttpCookie("userInfo");
        userInfo["UserName"] = "Jishan siddique";
        userInfo["UserColor"] = "Black";
        userInfo.Expires.Add(new TimeSpan(0, 1, 0));
        Response.Cookies.Add(userInfo);
