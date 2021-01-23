    public void Group()
        {
            var groupQuery = from s2 in s
                             where s2 != null
                             group s2 by s2.City;
            foreach (var s1 in groupQuery)
            {
                Console.WriteLine("Group: {0}", s1.Key);
                foreach(var s in s1)
                {
                    Console.WriteLine("Student: {0}", s.FirstName);
                }
            }
        }
