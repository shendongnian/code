    public static T? Parse<T>(object obj)
        where T : struct
    {
        if (obj == null) return null;
        try
        {
            return (T)System.Convert.ChangeType(obj, typeof(T));
        }
        catch (FormatException) { return null; }
        catch (InvalidCastException) { return null; }
    }
    case "TotalInvoice": Cost = NullableExtensions.Parse<float>(e.NewValues[key]); break;
