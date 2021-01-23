            private bool LessThan7DaysApart(DateTime d1, DateTime d2)
            {
                return (d1 - d2).Duration() < new TimeSpan(7, 0, 0, 0);
            }
    
    
            private void Match()
            {
                List<User> listfortype0 = users.Where(u => u.UserType == 0).ToList();
                List<User> listfortype1 = users.Where(u => u.UserType == 1).ToList();
    
                foreach (User u in listfortype0)
                {
                    List<User> tmp = listfortype1.Where(u2 => LessThan7DaysApart(u2.SignUpDate, u2.SignUpDate)).ToList();
                    if (tmp.Count > 0)
                    {
                        List<User> matchedusers = new List<User> { u, tmp[0] };                    
                        listfortype1.Remove(tmp[0]);
                    }
                }
            }
