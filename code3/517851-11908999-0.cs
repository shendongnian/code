            private static string DisplayCriteria(Criteria criteriaObject)
            {
                string criteria = "";
                foreach(Criteria c in criteriaObject)
                {
                    if (c.Criteria.Count() > 0)
                    {
                        criteria += string.Format("({0}" + System.Environment.NewLine, c.Display);
                        criteria += string.Format("{0})" + System.Environment.NewLine, DisplayCriteria(c.Criteria));
                    }
                    else
                    {
                        criteria += string.Format("[{0}]" + System.Environment.NewLine, c.Display);
                    }
                }
                return criteria;
            }
    
            // your code  ...
            DisplayCriteria(rule.SearchCriteria.Criteria);
            // your code  ...
