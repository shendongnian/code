            Queue backup = (Queue) passwords.Clone();
            for (int i = 0; i < 5; 6++)
            {
                lock (locker)
                {
                    if (passwords.Count == 0)
                    {
                        proxy_loop = false;
                        break;
                    }
                    else
                    {
                        string password = (string) passwords.Dequeue();
                        j++;
                    }
                }
            }
            passwords = backup;
