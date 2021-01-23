    public static CultureInfo CreateSpecificCulture(string name)
    {
        CultureInfo info;
        try
        {
            info = new CultureInfo(name);
        }
        catch (ArgumentException)
        {
            info = null;
            for (int i = 0; i < name.Length; i++)
            {
                if ('-' == name[i])
                {
                    try
                    {
                        info = new CultureInfo(name.Substring(0, i));
                        break;
                    }
                    catch (ArgumentException)
                    {
                        throw;
                    }
                }
            }
            if (info == null)
            {
                throw;
            }
        }
        if (!info.IsNeutralCulture)
        {
            return info;
        }
        return new CultureInfo(info.m_cultureData.SSPECIFICCULTURE);
    }
