            List<string> iz = new List<string>();
            DateTime start = DateTime.Now;
            for (int i = 0; i < 10000000; i++)
            {
                int zz = 5000;
                int yy = zz / (1 +i);
                zz = yy * i;
                DateTime end = DateTime.Now;
                if (start.Second != end.Second)
                {
                    start = end;
                    iz.Add(i.ToString());
                }
            }
