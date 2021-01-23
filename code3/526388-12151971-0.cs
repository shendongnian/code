    foreach (DataRow d in _ds.Tables[0].Rows)
             {
                 if (d["DataGridComboxBox_Control"].ToString() == "AVS_DB")
                 {
                     qcId = d["DataGridTextBox_QCList1"].ToString();
                     zipFolderPath = baseFolderPath;
                     patternFiles = Directory.GetFiles(zipFolderPath, "*.zip");
                     logMessage = "Unzipping file from path" + zipFolderPath + " \n file name:" + patternFiles[0];
                     Common.LogMessage(logMessage);
                     UnZipReleasePatch(zipFolderPath, patternFiles.First());
                     logMessage = "Deploying files" + zipFolderPath;
                     Common.LogMessage(logMessage);
                     DeployFiles();
                 }
             }
