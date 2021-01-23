            private XlsFile SetUpBackgroundColours(XlsFile excelFile)
        {
            var patternStyle = TFlxPatternStyle.Solid;
            TFlxFormat format = excelFile.GetDefaultFormat;
            format.FillPattern = new TFlxFillPattern { Pattern = patternStyle, FgColor = Color.Yellow }; //1
            format.VAlignment = TVFlxAlignment.top;
            format.HAlignment = THFlxAlignment.left;
            excelFile.AddFormat(format);
            format.FillPattern = new TFlxFillPattern { Pattern = patternStyle, FgColor = Color.LightBlue }; //2
            format.VAlignment = TVFlxAlignment.top;
            format.HAlignment = THFlxAlignment.left;
            excelFile.AddFormat(format);
            format.FillPattern = new TFlxFillPattern { Pattern = patternStyle, FgColor = Color.LightGray }; //3
            format.VAlignment = TVFlxAlignment.top;
            format.HAlignment = THFlxAlignment.left;
            excelFile.AddFormat(format);
            format.FillPattern = new TFlxFillPattern { Pattern = patternStyle, FgColor = Color.White }; //4
            format.VAlignment = TVFlxAlignment.top;
            format.HAlignment = THFlxAlignment.left;
            excelFile.AddFormat(format);
            return excelFile;
        }
