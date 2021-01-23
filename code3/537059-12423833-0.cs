    var outlook = new Application().GetNamespace("MAPI");
    var folder = outlook.GetDefaultFolder(OlDefaultFolders.olFolderContacts);
    foreach (var curr in folder.Items.OfType<DistListItem>())
    {
        Console.WriteLine(curr.DLName);
        for (int memberIdx = 1; memberIdx <= curr.MemberCount; memberIdx++)
        {
            var member = curr.GetMember(memberIdx);
            Console.WriteLine(member.Name);
        }
    }
