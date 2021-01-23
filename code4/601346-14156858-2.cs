        public static string RemoveB(string s)
            {
                s = s.Replace("hr.","$");
                s = s.Replace("hr","");
                s = s.Replace("$","hr.");
                return s;
            }
