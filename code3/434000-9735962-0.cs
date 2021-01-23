    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    /// <summary>
    /// Summary description for Matches
    /// </summary>
    
        public class Rounds
        {
            public int RoundNumber{get;set;}
            public List<Match> Matches{get;set;}
    
            public Rounds(int number, List<Match> matches)
            {
                this.RoundNumber = number;
                this.Matches = matches;
            }
        }
    
    	public class Match
    	{
    		public int MatchId{get;set;}
            public Team Team1{get;set;}
            public Team Team2 {get; set;}
            public Team WinningTeam { get; set; }
    
            public Match(int id, Team t1, Team t2) :this (id, t1, t2, null)
            {
              
            }
    
            public Match(int id, Team t1, Team t2, Team t3)
            {
                this.MatchId = id;
                this.Team1 = t1;
                this.Team2 = t2;
                this.WinningTeam = t3;
            }
    	}
    
        public class Team
        {
            public int TeamId {get;set;}
            public string TeamName {get;set;}
    
            public Team(int id, string name)
            {
                this.TeamId = id;
                this.TeamName = name;
            }
        }
