    Dictionary<DateTime, Dictionary<string, List<KeyValuePair<int, int>>>> dicData = new Dictionary<DateTime, Dictionary<string, List<KeyValuePair<int, int>>>>();
            //dt is your result from SQL query
            foreach (DataRow dr in dt.Rows)
            {
                DateTime dtm = DateTime.Parse(dr["DateTime"].ToString());
                string queue = dr["Queue"].ToString();
                int hours = int.Parse(dr["Hours"].ToString());
                int cycles = int.Parse(dr["Cycles"].ToString());
                //Adding Distinct DateTime objects as Key
                if(!dicData.ContainsKey(dtm))
                {
                    dicData[dtm] = new Dictionary<string, KeyValuePair<int, int>>();
                }
                //Adding distinct Queue object as Key under the DateTime dictionary
                if (!dicData.ContainsKey(queue))
                {
                    dicData[dtm][queue] = new List<KeyValuePair<int, int>>();
                }
                dicData[dtm][queue].Add(new KeyValuePair<int, int>(hours, cycles));
            }
