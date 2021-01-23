    bool localMaximumReached = false;    
            while (true)
            {
                if (varA < 8.0f)
                {
                    if (!localMaximumReached)
                    {
                        varA += 1.0f;
                        if (varA >= 8.0f)
                            localMaximumReached = true;
                    }
                    else
                        varA -= 2.0f;
                }
                else
                    break;
             }
