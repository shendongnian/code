     Excel.FormatCondition condition = colorRange.FormatConditions.Add(
         XlFormatConditionType.xlCellValue, 
         XlFormatConditionOperator.xlEqual,
         "=\"Red Color\"", 
         Type.Missing, 
         Type.Missing, 
         Type.Missing, 
         Type.Missing, 
         Type.Missing);
