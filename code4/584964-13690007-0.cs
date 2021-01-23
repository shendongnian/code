    while (true)
                {
                    string acc = "";
                    lock (accslocker)
                    {
                        if (accs.Count == 0)
                        {
                            break;
                        }
                        else
                            acc = accs.Dequeue();
                    }
                    string cook = od_auth(acc);
                    if (cook != "badacc")
                    {
                        string gr;
                        while (true)
                        {
                            int h = ok_group_join(gr);
                            if (h == 0)
                                ok_group_post(gr);
                            else if (h == -1)
                            {
                              //How can I go to first while cycle?
                              break;
                            }
