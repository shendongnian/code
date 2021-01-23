            for (int i = 0; i < cell.Count(); i++)
            {
                if (cell[i].dies)
                {
                    if (animated && delay == 50)
                    {
                        cell.RemoveAt(i);
                        cellsdied += 1;
                        i--;
                    }
                    else
                    {
                        cell[i].willdie = true;
                    }
                }
            }
