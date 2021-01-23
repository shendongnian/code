    public static List<string> GetMenuItems(List<int> userRoles)
        {
            var roleids = new List<int>();
            roleids.Add(1);
            roleids.Add(2);
            roleids.Add(3);
            var Links = new Dictionary<int, List<string>>()
            {
                 {1,new List<String> {"Home","About Us","Logout","Help"}},
                 {2,new List<String>{"Home","Products","Logout","Help"}},
                 {3,new List<String>{"Home","Customers","Users","Help"}}
            };
            var roleLinks = Links
                .Where(item => userRoles.Contains(item.Key))
                .SelectMany(item => item.Value)
                .ToList()
                .Distinct();
        }
