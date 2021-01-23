    FormatCondition format =(FormatCondition)( targetSheet.get_Range("D1:E10",
                    Type.Missing).FormatConditions.Add(XlFormatConditionType.xlExpression, XlFormatConditionOperator.xlEqual,
                    "=$D1=$E1", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing));
                
                format.Font.Bold = true;
                format.Font.Color = 0x000000FF;
