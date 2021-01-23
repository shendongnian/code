     foreach (Type objType in assembly.GetTypes())
                    {
                        //List<string> listInner = new List<string>();
                        var listInner = new HashSet<string>();
                        listInner.Add(objType.FullName);
                        foreach (MemberInfo obMember in objType.GetMembers())
                        {
                            listInner.Add(obMember.MemberType + " " + obMember.ToString());
    
                        }
                     }
