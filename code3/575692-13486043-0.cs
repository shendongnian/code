     Parallel.For(0,NumSymWatching , x =>
                    {
                        String conString = @"Data Source=TEJ-HP\SQLSERVER2012;Initial Catalog=DRMinutesData;Persist Security Info=True;User ID=sa;Password=sql;Pooling=false;";
                        SqlConnection hConnectionBars = new SqlConnection(conString);
                        hConnectionBars.Open();
                        SqlCommand hCommandBars = new SqlCommand();
                        hCommandBars.Connection = hConnectionBars;
                        
                        BuildHistoricalBarData(A[x], B[x], beginFilterTimeMinutes, hCommandBars);
                        hConnectionBars.Dispose();
                        hConnectionBars = null;
            
                    });
