        var up = from u in en.aspnet_Users
                         join p in en.Permissions
                             on u.UserId equals p.UserId into pu
                         from p2 in pu.DefaultIfEmpty()
                         where p2.MediaId == this.MediaId && p2.Valid == true
                         select p2;
                var ul = from us in en.aspnet_Users
                         join pm in up
                              on us.UserId equals pm.UserId into pm1
                         from pm2 in pm1.DefaultIfEmpty()
                         orderby us.LoweredUserName
                         select new PermissionInfo
                         {
                             Permission = (pm2 == null ? -1 : pm2.Permission1),
                             UserName = us.UserName,
                             UserId = us.UserId,
                             PermissionId = (pm2 == null ? -1 : pm2.PermissionId)
                         };
                ret = ul.ToList();
