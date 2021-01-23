    select new SomeKindOfUser
                            {
                                UserId = u.UserId,
                                UserName = u.UserName,
                                Email = mem.Email,
                                IsLockedOut = mem.IsLockedOut,
                                IsApproved = mem.IsApproved,
                                CreateDate = mem.CreateDate,
                                CompanyName = companies.CompanyName
                            };
