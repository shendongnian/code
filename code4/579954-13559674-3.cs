    public partial class Program
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ...
        }
        private class Team
        {
            public string Name { get; set; }
        }
         private static class cm
         {
             static cm()
             {
                 nextMatches =
                     new Team[][]
                         {
                             new[] { new Team { Name = "TeamA" }, new Team { Name = "TeamB" }},
                             new[] { new Team { Name = "TeamC" }, new Team { Name = "TeamD" }},
                             new[] { new Team { Name = "TeamE" }, new Team { Name = "TeamF" }},
                             new[] { new Team { Name = "TeamG" }, new Team { Name = "TeamH" }},
                             new[] { new Team { Name = "TeamI" }, new Team { Name = "TeamJ" }},
                             new[] { new Team { Name = "TeamK" }, new Team { Name = "TeamL" }},
                             new[] { new Team { Name = "TeamM" }, new Team { Name = "TeamN" }},
                             new[] { new Team { Name = "TeamO" }, new Team { Name = "TeamP" }},
                             new[] { new Team { Name = "TeamQ" }, new Team { Name = "TeamR" }},
                         };
             }
             public static Team[][] nextMatches { get; set; }
         }
    }
