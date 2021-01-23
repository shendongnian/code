        private string BuildQuery()
        {
            string MethodResult = "";
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM Table1");
                List<string> Clauses = new List<string>();
                Clauses.Add("Col1 = 0");
                Clauses.Add("Col2 = 1");
                Clauses.Add("Col3 = 2");
                
                bool FirstPass = true;
                if(Clauses != null && Clauses.Count > 0)
                {
                    foreach(string Clause in Clauses)
                    {
                        if (FirstPass)
                        {
                            sb.Append(" WHERE ");
                            FirstPass = false;
                        }
                        else
                        {
                            sb.Append(" AND ");
                        }
                        sb.Append(Clause);
                    }
                }
                MethodResult = sb.ToString();
            }
            catch //(Exception ex)
            {
                //ex.HandleException()
            }
            return MethodResult;
        }
