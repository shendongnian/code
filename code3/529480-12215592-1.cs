    Type[] types = Assembly.GetExecutingAssembly().GetTypes();
    foreach (Type toCheck in toProcess)
    {
        MemberInfo[] memberInfos = toCheck.GetMembers(BindingFlags.NonPublic | BindingFlags.Public | OtherBindingFlagsYouMayNeed);
        //Loop over the membersInfos and do what you need to such as retrieving their names
        // and adding them to a file
    }
