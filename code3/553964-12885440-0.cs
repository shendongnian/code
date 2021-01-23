    private Boolean number(string obj)
            {
                Regex r = new Regex(@"^[0-9]+$");
                Match m = r.Match(obj);
                if (m.Success == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
