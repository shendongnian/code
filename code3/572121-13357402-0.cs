    [TestClass]
    public class Test
    {
        const string filename = "TestData/TestExcel.xlsx";
    
        [TestMethod]
        [DeploymentItem(filename)] 
        public void GivenAnExcel_ConverToPDF()
        {
            var result = pdfConverter.ConvertExcelDocument(filename);
            AssertIsPdf(result);
        }
    }
