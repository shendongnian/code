    protected string FormatWithOxfordCommas(List<string> reasons)
            {
                string result = "";
                if (reasons.Count == 1)
                    result += reasons[0];
                else
                {
                    foreach (string item in reasons)
                    {
                        if (reasons.IndexOf(item) != reasons.Count - 1)
                            result += item + ", ";
                        else
                            result += "and " + item + ".";
                    }
                }
                return result;
            }
