     Excel.Range usedRange = Worksheet.UsedRange;
     usedRange.Interior.Color =    
     System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
      FormatCondition format = (FormatCondition)(Worksheet.get_Range("A1:D13",
                Type.Missing).FormatConditions.Add(XlFormatConditionType.xlExpression,    
      XlFormatConditionOperator.xlEqual,
                "=$A1=$D1", Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
      Type.Missing));
                
       format.Font.Bold = true;
       format.Interior.Color = 
       System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);//Duplicate values
