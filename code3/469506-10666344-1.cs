    public void MakePath(ref List<string> routes)
            {
                routes.Sort(); //just insert here
                for (int i = 0; i < routes.Count - 1; i++)
                {
                    for (int j = 0; j < routes.Count; j++)
                    {
                        if (routes[i][1] == routes[j][0])
                        {
                            var temp = routes[i + 1];
                            routes[i + 1] = routes[j];
                            routes[j] = temp;
                            continue;
                        }
                    }
                }
            }
