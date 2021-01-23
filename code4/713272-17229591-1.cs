                string[] first ={"00hr:00min:17sec",
    "00hr:03min:18sec",
    "00hr:05min:25sec",
    "01hr:39min:44sec"};
                string[] second = new string[first.Length];
                string pattern = @"([0-9]{2})hr:([0-9]{2})min:([0-9]{2})sec";
                for (int i = 0; i < first.Length; i++)
                {
                    Match match = Regex.Match(first[i],pattern);
                    if (match.Success)
                    {
                        int hour = int.Parse(match.Groups[1].Value);
                        if (hour > 0)
                            second[i] = hour + "hr ago";
                        else
                        {
                            int min = int.Parse(match.Groups[2].Value);
                            if (min > 0)
                                second[i] = min + "min ago";
                            else
                            {
                                int sec = int.Parse(match.Groups[3].Value);
                                if (sec > 0)
                                    second[i] = sec + "sec ago";
                            }
                        }
                    }
                }
