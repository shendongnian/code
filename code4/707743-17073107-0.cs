    namespace LinqExample
    {
        class Program
        {
            static void Main()
            {
                var Shows = new List<ShowData> { new ShowData { dataSource = "foo", EpisodeID = "foo", ShowID = "foo", SomeShowProperty = "showFoo" }};
                var Schedules = new List<ScheduleData> { new ScheduleData { dataSource = "foo", EpisodeID = "foo", ShowID = "foo", SomeScheduleProperty = "scheduleFoo" } };
    
                var results =
                    from show in Shows
                    join schedule in Schedules
                        on new { show.dataSource, show.ShowID, show.EpisodeID }
                        equals new { schedule.dataSource, schedule.ShowID, schedule.EpisodeID }
                    select new { show.SomeShowProperty, schedule.SomeScheduleProperty };
    
                foreach (var result in results)
                {
                    Console.WriteLine(result.SomeShowProperty + result.SomeScheduleProperty); //prints "showFoo scheduleFoo"
                }
    
                Console.ReadKey();
            }
        }
    
        public class ShowData
        {
            public string dataSource { get; set; }
            public string ShowID { get; set; }
            public string EpisodeID { get; set; }
            public string SomeShowProperty { get; set; }
        }
    
        public class ScheduleData
        {
            public string dataSource { get; set; }
            public string ShowID { get; set; }
            public string EpisodeID { get; set; }
            public string SomeScheduleProperty { get; set; }
        }
    }
