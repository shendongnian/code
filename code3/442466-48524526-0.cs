     foreach (var item in collection)
                {
                    if (cnt < 50)
                    {
                        cnt++;
                        DoWork(item);
                    }
                    else
                    {
                        bool stayinLoop = true;
                        while (stayinLoop)
                        {
                            Thread.Sleep(20000);
                            if (cnt < 30)
                            {
                                stayinLoop = false;
                                DoWork(item);
                            }
                        }
                    }
                }
