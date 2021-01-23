     var groupedUsers = from user in users
                               group user by user.User into userGroup
                               select new
                               {
                                   User = userGroup.Key,
                                   userHobies =
                                       userGroup.Aggregate((a, b) => 
                                           new { User = a.User, Hobby = (a.Hobby + ", " + b.Hobby) }).Hobby
                               }
                                ;
            foreach (var x in groupedUsers)
            {
                Debug.WriteLine(String.Format("{0} {1}", x.User, x.userHobies));
            }
