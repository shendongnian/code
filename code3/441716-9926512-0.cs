        using (Process excelProcess = new Process())
        {
            excelProcess.StartInfo.FileName = Assembly.GetAssembly(typeof(MyClassInExcelApplicationProject)).Location;
            excelProcess.Start();
        }
