        public List<Cookie> GetAllCookies(CookieContainer cc)
        {
            List<Cookie> lstCookies = new List<Cookie>();
            Hashtable table = (Hashtable)cc.GetType().InvokeMember("m_domainTable", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.Instance, null, cc, new object[] { });
           
            foreach (var pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    foreach (Cookie c in colCookies) lstCookies.Add(c);
            }
           
            return lstCookies;
        }
        public string ShowAllCookies(CookieContainer cc)
        {
            StringBuilder sb = new StringBuilder();
            List<Cookie> lstCookies = GetAllCookies(cc);
            sb.AppendLine("=========================================================== ");
            sb.AppendLine(lstCookies.Count + " cookies found.");
            sb.AppendLine("=========================================================== ");
            int cpt = 1;
            foreach (Cookie c in lstCookies)
                sb.AppendLine("#" + cpt++ + "> Name: " + c.Name + "\tValue: " + c.Value + "\tDomain: " + c.Domain + "\tPath: " + c.Path + "\tExp: " + c.Expires.ToString());
           
            return sb.ToString();
        }
