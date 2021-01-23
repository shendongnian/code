        class DomainComparer : StringComparer
        {
            public override int Compare(string x, string y)
            {
                if (x == null || y == null)
                {
                    return StringComparer.OrdinalIgnoreCase.Compare(x, y);
                }
                if (x.StartsWith("www.", StringComparison.OrdinalIgnoreCase))
                {
                    x = x.Substring(4);
                }
                if (y.StartsWith("www.", StringComparison.OrdinalIgnoreCase))
                {
                    y = y.Substring(4);
                }
                return StringComparer.OrdinalIgnoreCase.Compare(x, y);
            }
            public override bool Equals(string x, string y)
            {
                return Compare(x, y) == 0;
            }
            public override int GetHashCode(string obj)
            {
                if (obj.StartsWith("www.", StringComparison.OrdinalIgnoreCase))
                {
                    obj = obj.Substring(4);
                }
                return StringComparer.OrdinalIgnoreCase.GetHashCode(obj);
            }
        }
        /// <summary>
        /// this is a hackfix for microsoft bug, where cookies are not shared between www.domain.com and domain.com
        /// </summary>
        /// <param name="cc"></param>
        static void ImproveCookieContainer(CookieContainer cc)
        {
            Hashtable table = (Hashtable)cc.GetType().InvokeMember(
                "m_domainTable",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.Instance,
                null, cc, new object[] { });
            var comparerPreperty = table.GetType().GetField("_keycomparer", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.Instance);
            if (comparerPreperty != null)
            {
                comparerPreperty.SetValue(table, new DomainComparer());
            }
        }
