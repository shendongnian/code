        public DateTime[] quikSortTim(DateTime[] primary, string mode, int left, int right)
        {
            if (primary.Length > 1)
            {
                int i = left, j = right;
                DateTime pivot = primary[left + (right - left) / 2];
                while (i <= j)
                {
                    if (mode == "asc")
                    {
                        while (DateTime.Compare(primary[i], pivot) < 0)
                            i++;
                        while (DateTime.Compare(primary[j], pivot) > 0)
                            j--;
                    }
                    else
                    {
                        while (DateTime.Compare(primary[i], pivot) > 0)
                            i++;
                        while (DateTime.Compare(primary[j], pivot) < 0)
                            j--;
                    }
                    if (i <= j)
                    {
                        DateTime holdoverB = primary[i];
                        primary[i] = primary[j];
                        primary[j] = holdoverB;
                        
                        string holdover = last[i];
                        last[i] = last[j];
                        last[j] = holdover;
                        holdover = first[i];
                        first[i] = first[j];
                        first[j] = holdover;
                        i++;
                        j--;
                    }
                }
                if (j > left)
                    primary = quikSortTim(primary, mode, left, j);
                if (i < right)
                    primary = quikSortTim(primary, mode, i, right);
            }
            return primary;
        }
        public string[] quikSortStr(string[] primary, string type, string mode, int left, int right)
        {
            if (primary.Length > 1)
            {
                int i = left, j = right;
                string pivot = primary[left + (right - left) / 2];
                while (i <= j)
                {
                    if (mode == "asc")
                    {
                        while (String.Compare(primary[i], pivot) < 0)
                            i++;
                        while (String.Compare(primary[j], pivot) > 0)
                            j--;
                    }
                    else
                    {
                        while (String.Compare(primary[i], pivot) > 0)
                            i++;
                        while (String.Compare(primary[j], pivot) < 0)
                            j--;
                    }
                    if (i <= j)
                    {
                        string holdover = primary[i];
                        primary[i] = primary[j];
                        primary[j] = holdover;
                        if (type == "first")
                        {
                            holdover = last[i];
                            last[i] = last[j];
                            last[j] = holdover;
                        }
                        else
                        {
                            holdover = first[i];
                            first[i] = first[j];
                            first[j] = holdover;
                        }
                        DateTime holdoverBeta = bDay[i];
                        bDay[i] = bDay[j];
                        bDay[j] = holdoverBeta;
                        i++;
                        j--;
                    }
                }
                if (j > left)
                    primary = quikSortStr(primary, type, mode, left, j);
                if (i < right)
                    primary = quikSortStr(primary, type, mode, i, right);
            }
            return primary;
        }
