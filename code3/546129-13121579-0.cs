            PropertyInfo[] props = typeof(MyUserData).GetProperties();
            var results = from info in userInfo
                          from p in props
                          where listOfFields.Contains(p.Name)
                          select new
                          {
                              FieldName= p.Name,
                              UserId= info.UserId,
                              FieldValue= p.GetValue(info, null)
                          };
            foreach (var item in results)
            {
                Console.WriteLine("(userId = {0}) {1} = {2}", item.UserId, item.FieldName, item.FieldValue);
            }
