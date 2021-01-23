            List<String> strlist = new List<string>();
            strlist.Add("st1");
            strlist.Add("st2");
            strlist.Add("st3");
            string query = "SELECT Column1 FROM Table1 WHERE Column1 IN (";
            for (int i = 0; i < strlist.Count; i++)
            {
                query += "\'" + strlist[i] + "\'" + (i == strlist.Count - 1 ? "" : ",");
            }
            query += ")";
