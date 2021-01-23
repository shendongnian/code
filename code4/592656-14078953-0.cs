            Pushpin t1 = new Pushpin();
            t1.Tag = "t1";
            map1.Children.Add(t1);
            Pushpin t2 = new Pushpin();
            t2.Tag = "t2";
            map1.Children.Add(t2);
            Pushpin t3 = new Pushpin();
            t3.Tag = "t3";
            map1.Children.Add(t3);
            var ps = from p in map1.Children 
                     where ((string)((Pushpin)p).Tag) == "t1" 
                     select p;
            var psa= ps.ToArray();
            for (int i = 0; i < psa.Count();i++ )
            {
                map1.Children.Remove(psa[i]);
            }
