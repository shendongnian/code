    using Microsoft.Office.Interop.Excel;
    <...>
            formatConditionObj = (FormatCondition)myRange.FormatConditions
                .Add(XlFormatConditionType.xlExpression, 
                Type.Missing, true, Type.Missing, Type.Missing, 
                Type.Missing, Type.Missing, Type.Missing);
            formatConditionObj.Interior.ColorIndex = 5;
            Range myNewRange = ws.Range["a10:a15"];
            formatConditionObj.ModifyAppliesToRange(myNewRange);
     <...>
