        using (Process excelProcess = new Process())
        {
            excelProcess.StartInfo.FileName = Assembly.GetAssembly(typeof(SomeClassInExcelApplicationProject)).Location;
            excelProcess.Start();
        }
