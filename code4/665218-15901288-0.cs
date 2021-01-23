     public class LeagueRow
        {
            public String teamName { get; set; }
            public String managerName { get; set; }
            public Int32 played { get; set; }
            public Int32 won { get; set; }
            public Int32 draw { get; set; }
            public Int32 lost { get; set; }
            public Int32 goalsFor { get; set; }
            public Int32 goalsAgainst { get; set; }
            public Int32 goalDifference { get; set; }
            public Int32 points { get; set; }
            public override string ToString()
            {
                return string.Format("TeamName: {0}, ManagerName: {1}", teamName, managerName);
            }
        }
