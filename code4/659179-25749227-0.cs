            [TestCategory("THISISATEST")] 
            public void TestResourcesReacheability() 
            { 
                byte[] x = NAMESPACE.Properties.Resources.ExcelTestFile; 
                string fileTempLocation = Path.GetTempPath() + "temp.xls"; 
                System.IO.File.WriteAllBytes(fileTempLocation, x);   
    
                File.Copy(fileTempLocation, "D:\\new.xls"); 
            }
