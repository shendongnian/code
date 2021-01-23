    var users = from u in xdoc.Root.Elements()
                where u.Elements().Any()
                select new User {
                     Name = u.Name.LocalName,
                     ControlNumber = u.Elements().Select(cn => (int)cn).ToList()
                 };
    foreach(var user in users)
         UserClassDict.Add(user.Name, user);
