    public static class PeopleExtensions
    {                             
        private static List<string> _distinctShopTowns;
        private static List<Shop> _shops;
        public static List<Shop> Shops
        {
            get { return _shops; }
            set {
                _shops = value;
                _distinctShopTowns = _shops
                    .Select(shop => shop.town)
                    .Distinct()
                    .ToList();
            } 
        }
        public static IEnumerable<Person> PeopleInTownsWithShops(this IEnumerable<Person> people)
        {
            return people.Where(p => _distinctShopTowns.Contains(p.town));
        }
    }
