    var allContactTypes = new List<int>() { 1, 2 };
    var urlTypeMapping = contacts.GroupBy(c => c.ContactTypeID)
        .ToDictionary(grp => grp.Key, grp => grp.Select(c => c.url));
    foreach (var type in urlTypeMapping)
    {
        var typeUrl = type.Value.FirstOrDefault();
        if (typeUrl != null)
        {
            switch (type.Key)
            {
                case 1:
                    FacebookIcon.NavigateUrl = "http://facebook.com/" + typeUrl;
                    break;
                case 2:
                    GoogleIcon.NavigateUrl = "http://Google.com/" + url.First();
                    break;
                default:
                    throw new ArgumentException("Invalid type!");
            }
        }
    }
