    public static Range Cell
    {
        get
        {
            var mockCell = Substitute.For<Range>();
            mockCell.Address.Returns("$A$1");
            mockCell.Formula = "=1+1";
            mockCell.ToString().Returns(mockCell.Formula.ToString());
            //mockCell.ToString().Returns(info => mockCell.Formula.ToString());
            //SubstituteExtensions.Returns(mockCell.ToString(),  mockCell.Formula.ToString());
            mockCell.Worksheet.Returns(Sheet);
            mockCell.Worksheet.Name.Returns(MockSheetName);
    
            return mockCell;
        }
    }
