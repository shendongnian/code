    private void Select(string strKind,int Rank, string Blah)
            {
                var strWhere ="";
                if(strKind == "RANK")
                {
                    strWhere  = "where P.IDRANK ==" + Rank;
                }
                else 
                {
                    strWhere  = "where P.IDRANK == " + Rank + " && P.BLAH == " + Blah;
                }
                
                DBEntities MyDB = new DBEntities();
                var Query1 = from P in MyDB.Per
                                strWhere 
                             select P;
            }
