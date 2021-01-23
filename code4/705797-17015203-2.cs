    var query = from user in context.Users
                let previousUser = context.Users
                    .Where( u => u.SignUpDate < user.SignUpDate )
                    .OrderBy( u => u.SignUpDate )
                    .FirstOrDefault()
                select new
                {
                    User = user,
                    PreviousUser = previousUser,
                    IsDuplicate = previousUser != null && previousUser.UserType != user.UserType,
                    SignUpDaysApart = user.SignUpDate.Subtract( previousUser.SignUpDate )
                };
