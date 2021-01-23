    public static IEnumerable<CSVRow> GetRows(
        this CSVReader reader, int idGreaterThan, int idLessThan)
    {
        for (int i = idGreaterThan + 1; i < idLessThan; i++)
        {
            yield return new CSVRow(reader, i);
        }
    }
