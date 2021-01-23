                       using (FullTextSqlQuery q = GetFullTextSqlQuery(web))
                        {
                            q.QueryText = sqlQuery.ToString();
                            rt = ((ResultTableCollection)q.Execute())[ResultType.RelevantResults];
                            Logging.LogMessage(rt.RowCount.ToString());
                        }
