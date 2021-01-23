        //string arg filled with the value of "varyByCustom" in your web.config
        public override string GetVaryByCustomString(HttpContext context, string arg)
        {
            if (arg == "User")
                 {
                 // depends on your authentication mechanism
                 return "User=" + context.User.Identity.Name;
                 //return "User=" + context.Session.SessionID;
                 }
            return base.GetVaryByCustomString(context, arg);
        }
