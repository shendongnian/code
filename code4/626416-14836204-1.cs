            static void GenericEntry<T, TK>(string userid, string environment, DBContext context)
            {
    
                // Magic happens here
                var results = GetResults();
                
                // More magic
    
                var resultList = new List<string>();
                foreach (var row in results)
                {
                    var poco = row.ToJson();
                    resultList.Add(poco);
                }
                return String.Format("[{0}]", String.Join(resultList, ", "));
            }
