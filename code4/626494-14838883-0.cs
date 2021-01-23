    public static bool IsValid(this string XML)
    {
        try
        {
            XElement temp = XElement.Parse(XML);
        }
        catch (FormatException)
        {
            return false;
        }
        catch (XmlException)
        {
            return false;
        }
        return true;
    }
