     // assign
                    var cellsToMerge = "A1:C3";
    
                    // mock
                    var ws = new Mock<Worksheet>();
                    var range = new Mock<Range>();
                    ws.Setup(x => x.get_Range(It.IsAny<object>(), It.IsAny<object>())).Returns(range.Object);
                    
                    range.Setup(x => x.Merge(It.IsAny<object>()));
                    // act 
                    var process = new RenderExcel();
                    process.CreateExcelWorkSheet("fileName");
                    process.MergeCellsTogether((Worksheet)ws.Object, cellsToMerge);
    
                    // assert
                    range.VerifyAll();
