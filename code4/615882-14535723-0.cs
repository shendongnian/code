    static bool match(TableRow row, string _Name, string _Hair, string _Eyes)
            {
                    return (row.Name == _Name || row.Name == "*") && (row.Hair == _Hair || row.Hair == "*") && (row.Eyes == _Eyes || row.Eyes == "*");
            }
     
            static int score(TableRow row)
            {
                    //can assume these already "match"
                    var score = 0;
                    score +=  row.Name == "*" ? 1000 : 2000; 
                    score +=  row.Hair == "*" ? 100 : 200; 
                    score +=  row.Eyes == "*" ? 10 : 20; 
                    return score;
            }
     
            static int FindID(string _Name, string _Hair, string _Eyes)
            {
                
                var s = from row in _MyTable.Table
                            where match(row, _Name, _Hair, _Eyes)
                            orderby score(row) descending
                            select row;
     
                    
                var match = s.FirstOrDefault();
                if(match != null) return match.ID;
                return -1; //i guess?
            }
