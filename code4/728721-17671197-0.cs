    public static IEnumerable<Member> SelectMembers(this DbSet<Member> members, string name, string surname)
    {
     return from m in members 
            where m.Name == name and m.Surname == usrname
            select m;
    }
