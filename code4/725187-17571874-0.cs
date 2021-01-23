    var t = from UserDetail u in list                    
            select new {
                cell = new object[] {
                    u.UserId.ToString(),
                    u.UserName,
                    u.Password,
                    u.Pin != null && u.Pin.UserPin != null ? u.Pin.UserPin : ""
                }
            };
