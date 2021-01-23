     DataTable Rank(DataTable dt, string partitionBy, string orderBy, int whichRank)
       {
            DataView dv = new DataView(dt);
            dv.Sort = partitionBy + ", " + orderBy + " DESC";
            DataTable rankDt = dv.ToTable();
            rankDt.Columns.Add("Rank");
            int rank = 1;
            for (int i = 0; i < rankDt.Rows.Count - 1; i++)
            {
                rankDt.Rows[i]["Rank"] = rank;
                DataRow thisRow = rankDt.Rows[i];
                DataRow nextRow = rankDt.Rows[i + 1];
                if (thisRow[partitionBy].ToString() != nextRow[partitionBy].ToString())
                    rank = 1;
                else
                    rank++;
            }
            DataView selectRankdv = new DataView(rankDt);
            selectRankdv.RowFilter = "rank = " + whichRank;
            return selectRankdv.ToTable();
      }
