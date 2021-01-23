    var str = from userInfo in context.UserInfos
              where user.UserName == userName
              select new
              {
                  UserName = p.UserName,
                  FirstName = p.UserInfo.FirstName,
                  LastName = p.UserInfo.LastName,
                  Email = p.UserInfo.Membership.Email,
                  UserId = p.UserID
              };
