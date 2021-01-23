    private static void GetRSS(int start, int end)
    {
        var bunchSize = (end - start) / 4 + 1;
        var threads = new List<Thread>();
        for (int i = 0; i < 4; i++)
        {
            var currStart = start + i * bunchSize;
            var currEnd = currStart + bunchSize;
            if (currEnd > end)
            {
                currEnd = end;
            }
            var thread = new Thread(() =>
                                        {
                                            // thread logic using currStart and currEnd
                                            string content = string.Empty;
                                            using (WebClient client = new WebClient())
                                            {
                                                //some code here get html content
                                            }
                                            // some code here parse content
                                        });
            threads.Add(thread);
            thread.Start();
        }
        foreach (var thread in threads)
        {
            thread.Join();
        }
    }
