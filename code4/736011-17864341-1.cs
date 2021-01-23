        range.value = lines;
        range.TextToColumns(
            range,
            Microsoft.Office.Interop.Excel.XlTextParsingType.xlDelimited,
            Microsoft.Office.Interop.Excel.XlTextQualifier.xlTextQualifierNone,
            false,
            true    // This is flag to say it is tab delimited
        );
