    Range columnBRange = (Range)oSheet.Range[oSheet.Cells[1,2], oSheet.Cells[10,2]];
    Range columnARange = (Range)oSheet.Range[oSheet.Cells[1,1], oSheet.Cells[1,1]];
    FormatCondition cond = (FormatCondition) ColumnBRange.FormatConditions.Add(XlFormatConditionType.xlCellValue, XlFormatConditionOperator.xlNotEqual, "="+ColumnARange.Address[false,true]);
    cond.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red); //Red letters
    cond.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightYellow); //Light yellow cell background
