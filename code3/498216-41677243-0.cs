    private bool IsValidIP(String ip)
        {
            try
            {
                if (ip == null || ip.Length == 0)
                {
                    return false;
                }
                String[] parts = ip.Split(new[] { "." }, StringSplitOptions.None);
                if (parts.Length != 4)
                {
                    return false;
                }
                foreach (String s in parts)
                {
                    int i = Int32.Parse(s);
                    if ((i < 0) || (i > 255))
                    {
                        return false;
                    }
                }
                if (ip.EndsWith("."))
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
