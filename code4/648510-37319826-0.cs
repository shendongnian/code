    // Create Variable list
    var variables = new List<Variable>
    {
        new Variable
        {
            Label = "The variable Label",
            ValueLabels = new Dictionary<double, string>
                    {
                        {1, "Label for 1"},
                        {2, "Label for 2"},
                    },
            Name = "avariablename_01",
            PrintFormat = new OutputFormat(FormatType.F, 8, 2),
            WriteFormat = new OutputFormat(FormatType.F, 8, 2),
            Type = DataType.Numeric,
            Width = 10,
            MissingValueType = MissingValueType.NoMissingValues
        },
        new Variable
        {
            Label = "Another variable",
            ValueLabels = new Dictionary<double, string>
                        {
                            {1, "this is 1"},
                            {2, "this is 2"},
                        },
            Name = "avariablename_02",
            PrintFormat = new OutputFormat(FormatType.F, 8, 2),
            WriteFormat = new OutputFormat(FormatType.F, 8, 2),
            Type = DataType.Numeric,
            Width = 10,
            MissingValueType = MissingValueType.OneDiscreteMissingValue
        }
    };
    // Set the one special missing value
    variables[1].MissingValues[0] = 999;  
    
    // Default options
    var options = new SpssOptions();
    
    using (FileStream fileStream = new FileStream("data.sav", FileMode.Create, FileAccess.Write))
    {
        using (var writer = new SpssWriter(fileStream, variables, options))
        {
            // Create and write records
            var newRecord = writer.CreateRecord();
            newRecord[0] = 15d;
            newRecord[1] = 15.5d;
            writer.WriteRecord(newRecord);
    
            newRecord = writer.CreateRecord();
            newRecord[0] = null;
            newRecord[1] = 200d;
            writer.WriteRecord(newRecord);
            writer.EndFile();
        }
    }
