    public IApp ConvertToIApp(Object element)
    {
        IApp result = (IApp)element;
        TimeSpan span = result.end - result.start;
        if (span.TotalDays > 1)
        {
            result.Status = "Excellent";
        }
        return result;
    }
