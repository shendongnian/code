    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace tournament
    {
        class Program
        {
            static string GenerateHTMLResultsTable(Tournament tournament)
            {
                int match_white_span;
                int match_span;
                int position_in_match_span;
                int column_stagger_offset;
                int effective_row;
                int col_match_num;
                int cumulative_matches;
                int effective_match_id;
                int rounds = tournament.TournamentRoundMatches.Count;
                int teams = 1 << rounds;
                int max_rows = teams << 1;
                StringBuilder HTMLTable = new StringBuilder();
    
                HTMLTable.AppendLine("<style type=\"text/css\">");
                HTMLTable.AppendLine("    .thd {background: rgb(220,220,220); font: bold 10pt Arial; text-align: center;}");
                HTMLTable.AppendLine("    .team {color: white; background: rgb(100,100,100); font: bold 10pt Arial; border-right: solid 2px black;}");
                HTMLTable.AppendLine("    .winner {color: white; background: rgb(60,60,60); font: bold 10pt Arial;}");
                HTMLTable.AppendLine("    .vs {font: bold 7pt Arial; border-right: solid 2px black;}");
                HTMLTable.AppendLine("    td, th {padding: 3px 15px; border-right: dotted 2px rgb(200,200,200); text-align: right;}");
                HTMLTable.AppendLine("    h1 {font: bold 14pt Arial; margin-top: 24pt;}");
                HTMLTable.AppendLine("</style>");
    
                HTMLTable.AppendLine("<h1>Tournament Results</h1>");
                HTMLTable.AppendLine("<table border=\"0\" cellspacing=\"0\">");
                for (int row = 0; row <= max_rows; row++)
                {
                    cumulative_matches = 0;
                    HTMLTable.AppendLine("    <tr>");
                    for (int col = 1; col <= rounds + 1; col++)
                    {
                        match_span = 1 << (col + 1);
                        match_white_span = (1 << col) - 1;
                        column_stagger_offset = match_white_span >> 1;
                        if (row == 0)
                        {
                            if (col <= rounds)
                            {
                                HTMLTable.AppendLine("        <th class=\"thd\">Round " + col + "</th>");
                            }
                            else
                            {
                                HTMLTable.AppendLine("        <th class=\"thd\">Winner</th>");
                            }
                        }
                        else if (row == 1)
                        {
                            HTMLTable.AppendLine("        <td class=\"white_span\" rowspan=\"" + (match_white_span - column_stagger_offset) + "\">&nbsp;</td>");
                        }
                        else
                        {
                            effective_row = row + column_stagger_offset;
                            if (col <= rounds)
                            {
                                position_in_match_span = effective_row % match_span;
                                position_in_match_span = (position_in_match_span == 0) ? match_span : position_in_match_span;
                                col_match_num = (effective_row / match_span) + ((position_in_match_span < match_span) ? 1 : 0);
                                effective_match_id = cumulative_matches + col_match_num;
                                if ((position_in_match_span == 1) && (effective_row % match_span == position_in_match_span))
                                {
                                    HTMLTable.AppendLine("        <td class=\"white_span\" rowspan=\"" + match_white_span + "\">&nbsp;</td>");
                                }
                                else if ((position_in_match_span == (match_span >> 1)) && (effective_row % match_span == position_in_match_span))
                                {
                                    HTMLTable.AppendLine("        <td class=\"team\">Team " + tournament.TournamentRoundMatches[col][effective_match_id].teamid1 + "</td>");
                                }
                                else if ((position_in_match_span == ((match_span >> 1) + 1)) && (effective_row % match_span == position_in_match_span))
                                {
                                    HTMLTable.AppendLine("        <td class=\"vs\" rowspan=\"" + match_white_span + "\">VS</td>");
                                }
                                else if ((position_in_match_span == match_span) && (effective_row % match_span == 0))
                                {
                                    HTMLTable.AppendLine("        <td class=\"team\">Team " + tournament.TournamentRoundMatches[col][effective_match_id].teamid2 + "</td>");
                                }
                            }
                            else
                            {
                                if (row == column_stagger_offset + 2)
                                {
                                    HTMLTable.AppendLine("        <td class=\"winner\">Team " + tournament.TournamentRoundMatches[rounds][cumulative_matches].winner + "</td>");
                                }
                                else if (row == column_stagger_offset + 3)
                                {
                                    HTMLTable.AppendLine("        <td class=\"white_span\" rowspan=\"" + (match_white_span - column_stagger_offset) + "\">&nbsp;</td>");
                                }
                            }
                        }
                        if (col <= rounds)
                        {
                            cumulative_matches += tournament.TournamentRoundMatches[col].Count;
                        }
                    }
                    HTMLTable.AppendLine("    </tr>");
                }
                HTMLTable.AppendLine("</table>");
    
                HTMLTable.AppendLine("<h1>Third Place Results</h1>");
                HTMLTable.AppendLine("<table border=\"0\" cellspacing=\"0\">");
                HTMLTable.AppendLine("    <tr>");
                HTMLTable.AppendLine("        <th class=\"thd\">Round 1</th>");
                HTMLTable.AppendLine("        <th class=\"thd\">Third Place</th>");
                HTMLTable.AppendLine("    </tr>");
                HTMLTable.AppendLine("    <tr>");
                HTMLTable.AppendLine("        <td class=\"white_span\">&nbsp;</td>");
                HTMLTable.AppendLine("        <td class=\"white_span\" rowspan=\"2\">&nbsp;</td>");
                HTMLTable.AppendLine("    </tr>");
                HTMLTable.AppendLine("    <tr>");
                HTMLTable.AppendLine("        <td class=\"team\">Team " + tournament.ThirdPlaceMatch.teamid1 + "</td>");
                HTMLTable.AppendLine("    </tr>");
                HTMLTable.AppendLine("    <tr>");
                HTMLTable.AppendLine("        <td class=\"vs\">VS</td>");
                HTMLTable.AppendLine("        <td class=\"winner\">Team " + tournament.ThirdPlaceMatch.winner + "</td>");
                HTMLTable.AppendLine("    </tr>");
                HTMLTable.AppendLine("    <tr>");
                HTMLTable.AppendLine("        <td class=\"team\">Team " + tournament.ThirdPlaceMatch.teamid2 + "</td>");
                HTMLTable.AppendLine("        <td class=\"white_span\">&nbsp;</td>");
                HTMLTable.AppendLine("    </tr>");
                HTMLTable.AppendLine("</table>");
                return HTMLTable.ToString();
            }
    
            static void Main(string[] args)
            {
                Tournament Test3RoundTournament = new Tournament(3);
                Tournament Test2RoundTournament = new Tournament(2);
                File.WriteAllText(@"C:\Tournament\results.html", GenerateHTMLResultsTable(Test2RoundTournament));
                File.WriteAllText(@"C:\Tournament\results.html", GenerateHTMLResultsTable(Test3RoundTournament));
                Console.ReadLine();
            }
        }
    }
