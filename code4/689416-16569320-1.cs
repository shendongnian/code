    public class Test
    {
        public void Exec()
        {
            var items = new List<Item>{ 
            new Item { DepartureTime = "01/08/2013 09:13:00", ArrivalTime = "01/08/2013 10:14:00", TravelClass="economy" , Price =        4700 },
            new Item { DepartureTime = "01/08/2013 09:13:00", ArrivalTime = "01/08/2013 10:14:00", TravelClass="first"   , Price =        8300 },
            new Item { DepartureTime = "01/08/2013 09:13:00", ArrivalTime = "01/08/2013 10:14:00", TravelClass="economy" , Price =        2750 },
            new Item { DepartureTime = "01/08/2013 09:13:00", ArrivalTime = "01/08/2013 10:14:00", TravelClass="first"   , Price =        3600 },
            new Item { DepartureTime = "01/08/2013 09:13:00", ArrivalTime = "01/08/2013 10:14:00", TravelClass="economy" , Price =        2000 },
            new Item { DepartureTime = "01/08/2013 10:11:00", ArrivalTime = "01/08/2013 11:14:00", TravelClass="economy" , Price =        4700 },
            new Item { DepartureTime = "01/08/2013 10:11:00", ArrivalTime = "01/08/2013 11:14:00", TravelClass="first"   , Price =        8300 },
            new Item { DepartureTime = "01/08/2013 10:11:00", ArrivalTime = "01/08/2013 11:14:00", TravelClass="economy" , Price =        2750 },
            new Item { DepartureTime = "01/08/2013 10:11:00", ArrivalTime = "01/08/2013 11:14:00", TravelClass="first"   , Price =        2950 },
            new Item { DepartureTime = "01/08/2013 10:11:00", ArrivalTime = "01/08/2013 11:14:00", TravelClass="economy" , Price =        2000 },
            new Item { DepartureTime = "01/08/2013 10:11:00", ArrivalTime = "01/08/2013 11:14:00", TravelClass="first"   , Price =        2800 },
        };
            var result = items
                            .GroupBy(groupedItems => new { groupedItems.DepartureTime, groupedItems.ArrivalTime, groupedItems.TravelClass })
                            .SelectMany(i => items
                                                 .Where(innerItem =>
                                                                        (innerItem.DepartureTime == i.Key.DepartureTime
                                                                        && innerItem.ArrivalTime == i.Key.ArrivalTime
                                                                        && innerItem.TravelClass == i.Key.TravelClass)
                                                                        && innerItem.Price == i.Min(ii => ii.Price))
                                                 .Select(innerItem => innerItem)
                                                 );
            foreach (var item in result)
                Console.WriteLine("Cheapest flight with departure at {0}, arrival at {1} and in travel class {2} costs {3}", item.DepartureTime, item.ArrivalTime, item.TravelClass, item.Price);
        }
        private class Item
        {
            public String DepartureTime { get; set; }
            public String ArrivalTime { get; set; }
            public String TravelClass { get; set; }
            public Int32 Price { get; set; }
        }
    }
