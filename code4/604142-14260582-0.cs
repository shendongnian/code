        System.AppDomain.CurrentDomain.AssemblyResolve += (o, e) =>
        {
            if (e.Name == "System.Web.Razor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35")
                return System.Reflection.Assembly.LoadFrom(Server.MapPath("~/bin/1.0/System.Web.Razor.dll"));
            return null;
        };
