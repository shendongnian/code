            List<int> l = new List<int>();
            for (int i = 1; i < 100; i++)
            {
                l.Add(i);
                l.Add(i * 2);
                l.Add(i * i);
            }
            Thread th = new Thread(new ThreadStart(() =>
            {
                int t=0;
                while (true)
                {
                    //Thread.Sleep(200);
                    switch (t)
                    {
                        case 0:
                            l.Add(t);
                            t = 1;
                            break;
                        case 1:
                            l.RemoveAt(t);
                            t = 0;
                            break;
                    }
                }
            }));
            th.Start();
            try
            {
                while (true)
                {
                    Array ai = l.ToArray();
                    //foreach (object o in ai)
                    //{
                    //    String str = o.ToString();
                    //}
                }
            }
            catch (System.Exception ex)
            {
                String str = ex.ToString();                	
            }
        }
