    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class Test : System.Web.UI.Page
    {
        List<Rounds> rounds = new List<Rounds>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowRoundMatchesUsingTable();
        }
    
        private List<Rounds> GetRoundMatchesDetails()
        {
            List<Team> teamList = new List<Team>();
            teamList.Add(new Team(1, "Arcenal"));
            teamList.Add(new Team(2, "Barsa"));
            teamList.Add(new Team(3, "Manchester"));
            teamList.Add(new Team(4, "Black Burn"));
            teamList.Add(new Team(5, "Ferrari"));
            teamList.Add(new Team(6, "Adidas"));
            teamList.Add(new Team(7, "Reebock"));
            teamList.Add(new Team(8, "Nike"));
    
            List<Match> matchList1 = new List<Match>();
            matchList1.Add(new Match(1, teamList.Find(lst => lst.TeamName == "Arcenal"), teamList.Find(lst => lst.TeamName == "Barsa")));
            matchList1.Add(new Match(1, teamList.Find(lst => lst.TeamName == "Manchester"), teamList.Find(lst => lst.TeamName == "Black Burn")));
            matchList1.Add(new Match(1, teamList.Find(lst => lst.TeamName == "Ferrari"), teamList.Find(lst => lst.TeamName == "Adidas")));
            matchList1.Add(new Match(1, teamList.Find(lst => lst.TeamName == "Reebock"), teamList.Find(lst => lst.TeamName == "Nike")));
    
            List<Match> matchList2 = new List<Match>();
            matchList2.Add(new Match(2, teamList.Find(lst => lst.TeamName == "Arcenal"), teamList.Find(lst => lst.TeamName == "Manchester")));
            matchList2.Add(new Match(2, teamList.Find(lst => lst.TeamName == "Adidas"), teamList.Find(lst => lst.TeamName == "Nike")));
    
            List<Rounds> rounds = new List<Rounds>();
    
            rounds.Add(new Rounds(1, matchList1));
            rounds.Add(new Rounds(2, matchList2));
    
            return rounds;
        }
    
        private void ShowRoundMatchesUsingTable()
        {
            IEnumerable<Rounds> roundsList = GetRoundMatchesDetails();
    
            if (roundsList == null || roundsList.Count() == 0) return;
    
            Table tbl = new Table();
    
            TableRow trHeaderRow = new TableRow();
            TableRow trDetailRow = new TableRow();
            TableCell tcDetails = new TableCell();
    
            foreach (Rounds round in roundsList)
            {
                TableHeaderCell th = new TableHeaderCell();
                th.Text = "Round : " + round.RoundNumber ;
                trHeaderRow.Cells.Add(th);
    
                if (round.Matches != null && round.Matches.Count > 0)
                {
                    tcDetails = new TableCell();
                    trDetailRow.Cells.Add(tcDetails);
                }
    
                foreach (Match m in round.Matches)
                {
                    Table dtlTable = new Table();
                    tcDetails.Controls.Add(dtlTable);
                   
                    TableRow tr1 = new TableRow();
                    TableCell tc = new TableCell();
                    tc.Text = m.Team1.TeamName;
                    tr1.Cells.Add(tc);
                    dtlTable.Rows.Add(tr1);
    
                    tr1 = new TableRow();
                    tc = new TableCell();
                    tc.Text = "Vs";
                    tr1.Cells.Add(tc);
                    dtlTable.Rows.Add(tr1);
    
                    tr1 = new TableRow();
                    tc = new TableCell();
                    tc.Text = m.Team2.TeamName;
                    tr1.Cells.Add(tc);
                    dtlTable.Rows.Add(tr1);
                }
            }
    
            tbl.Rows.Add(trHeaderRow);
            tbl.Rows.Add(trDetailRow);
            div.Controls.Add(tbl);
        }
    }
