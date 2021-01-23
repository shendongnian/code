    List<IApp> result = AppClassList.ConvertAll<IApp>(o =>
        {
            IApp result = (IApp)o;
            TimeSpan span = result .end - result .start;
            if (span.TotalDays > 1)
            {
               result.Status = "Excellent";
            }
            return result;
        });
