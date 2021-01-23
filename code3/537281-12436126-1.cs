    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
    internal class BoringEvent
    {
        public string EventStartStr { get; set; }
        public string EventTimeZone { get; set; }
        public string ProvinceState { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
    internal enum SortedBy
    {
        Ascending = 0,
        Descending
    }
    class ExpressionsTest
    {
        internal static List<BoringEvent> _allEvents = new List<BoringEvent>();
        internal static class HelperFunctions
        {
            public static DateTime strToTZDateTime(string startDate, 
                string timeZone)
            {
                //I'm too lazy to figure out dates by time zone.
                //Your function already has the logic, so why bother.
                //Let's assume the time zone is equal in this test case
                return DateTime.Parse(startDate);
            }
        }
        internal static void Main()
        {
            _allEvents.Add(new BoringEvent {
                EventStartStr = "12/31/1999", 
                //let's party like it's 1999 - (yawn) I'm stuck at this event :< 
                EventTimeZone = "en-us", 
                City = "Philadelphia", 
                ProvinceState = "Pennsylvania",
                Country = "United States of America"});
            _allEvents.Add(new BoringEvent
            {
                EventStartStr = "01/01/1970",
                EventTimeZone = "en-us",
                City = "New York",
                ProvinceState = "New York",
                Country = "United States of America"
            });
            IEnumerable<BoringEvent> sortedEvents = null;
            //sort by date
            Console.WriteLine("Sorting Events by Ascending date...");
            sortedEvents = _allEvents.SortEvents(SortedBy.Ascending,
                evt => HelperFunctions.strToTZDateTime(evt.EventStartStr, 
                    evt.EventTimeZone));
            Print(sortedEvents);
            //sort by country, then state, then city, then date
            Console.WriteLine("Sorting Events by Country, then ProvinceState, then City, then Date");
            sortedEvents = _allEvents.SortEvents(SortedBy.Descending, 
                evt => evt.Country, 
                evt => evt.ProvinceState, 
                evt => evt.City,
                evt => HelperFunctions.strToTZDateTime(evt.EventStartStr, 
                    evt.EventTimeZone).ToIsoFormat());  
            //I call ToIsoFormat() to sort the dates, which is not ideal, but is efficient nonetheless.  
            Print(sortedEvents);
            Console.Read();
        }
        private static void Print(IEnumerable<BoringEvent> events)
        {
            for(int i = 0; i < events.Count(); i++)
            {
                BoringEvent evt = events.ElementAt(i);
                Console.WriteLine("Event: {0}", i.ToString());
                Console.WriteLine("\tEventStartStr: {0}", evt.EventStartStr);
                Console.WriteLine("\tEventTimeZone: {0}", evt.EventTimeZone);
                Console.WriteLine("\tCity: {0}", evt.City);
                Console.WriteLine("\tProvinceState: {0}", evt.ProvinceState);
                Console.WriteLine("\tCountry: {0}", evt.Country);
            }
        }
    }
    internal static class BoringEventExtensions
    {
        public static IEnumerable<BoringEvent> SortEvents<T>(
            this IEnumerable<BoringEvent> events, 
            SortedBy sortByType,
            params Expression<Func<BoringEvent, T>>[] expressions)
        {
            IEnumerable<BoringEvent> retVal = null;
            switch(sortByType)
            {
                case SortedBy.Ascending:
                    retVal = BoringEventExtensions.SortEventsAsc<T>(events, expressions);
                    break;
                case SortedBy.Descending:
                    retVal = BoringEventExtensions.SortEventsDesc<T>(events, expressions);
                    break;
                default:
                    throw new InvalidOperationException(
                        string.Format("The SortedBy enumeration does not contain a case for the value of '{0}'.", 
                        Enum.GetName(typeof(SortedBy), sortByType)));
            }
            return retVal;
        }
        public static IEnumerable<BoringEvent> SortEventsAsc<T>(
            this IEnumerable<BoringEvent> events, 
            params Expression<Func<BoringEvent, T>>[] expressions)
        {
            IOrderedEnumerable<BoringEvent> sorted = null;
            for(int i = 0; i < expressions.Count(); i++)
            {
                Expression<Func<BoringEvent, T>> exp = 
                    (Expression<Func<BoringEvent, T>>)expressions[i];
                Func<BoringEvent, T> deleg = exp.Compile();
                if(i == 0)
                {
                    sorted = events.OrderBy(evt => deleg.Invoke(evt));
                }
                else
                {
                    sorted = sorted.ThenBy(evt => deleg.Invoke(evt));
                }
            }
            return sorted;
        }
        public static IEnumerable<BoringEvent> SortEventsDesc<T>(
            this IEnumerable<BoringEvent> events,
            params Expression<Func<BoringEvent, T>>[] expressions)
        {
            IOrderedEnumerable<BoringEvent> sorted = null;
            for (int i = 0; i < expressions.Count(); i++)
            {
                Expression<Func<BoringEvent, T>> exp = 
                    (Expression<Func<BoringEvent, T>>)expressions[i];
                Func<BoringEvent, T> deleg = exp.Compile();
                if (i == 0)
                {
                    sorted = events.OrderByDescending(evt => deleg.Invoke(evt));
                }
                else
                {
                    sorted = sorted.ThenByDescending(evt => deleg.Invoke(evt));
                }
            }
            return sorted;
        }
        public static string ToIsoFormat(this DateTime dateTime)
        {
            //The Sortable ("s") Format Specifier
            return dateTime.ToString("s");  // example 2009-06-15T13:45:30
        }
    }
