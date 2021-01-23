    private int LastUsedRow(Excel.Worksheet aSheet)
    {
        object hmissing = System.Reflection.Missing.Value;
        string usedAddress = aSheet.UsedRange.get_Address(hmissing, hmissing, Excel.XlReferenceStyle.xlA1, hmissing, hmissing);
        return int.Parse(usedAddress.Substring(usedAddress.LastIndexOf('$') + 1));
    }
