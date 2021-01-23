    Response.Clear();
    
            var downloadFileName = string.Format("" + FileName + ".zip");//string.Format("YourDownload-{0}.zip", DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss"));
            Response.ContentType = "application/zip";
            Response.AddHeader("Content-Disposition", "filename=" + downloadFileName);
    
            // Zip the contents of the selected files
            using (var zip = new ZipFile())
            {
                // Add the password protection, if specified
                if (!string.IsNullOrEmpty(txtZIPPassword.Text))
                {
                    zip.Password = txtZIPPassword.Text;
    
                    // 'This encryption is weak! Please see 
                   // zip.Encryption = EncryptionAlgorithm.WinZipAes128;
                }
    
                // Construct the contents of the README.txt file that will be included in this ZIP
                var readMeMessage = string.Format("Your ZIP file {0} contains the following files:{1}{1}", downloadFileName, Environment.NewLine);
    
                // Add the checked files to the ZIP
                foreach (ListItem li in cblFiles.Items)
                    if (li.Selected)
                    {
                        // Record the file that was included in readMeMessage
                        readMeMessage += string.Concat("\t* ", li.Text, Environment.NewLine);
    
                        // Now add the file to the ZIP (use a value of "" as the second parameter to put the files in the "root" folder)
                        zip.AddFile(li.Value, "Your Files");
                    }
    
                if (!String.IsNullOrEmpty(chkDocument.Value) && chkDocument.Checked == true)
                {
                    zip.AddFile(chkDocument.Value, "Cover Sheet");
                    readMeMessage += string.Concat("\t* ", lbldocName.Text.Trim(), Environment.NewLine);
                }
                // Add the README.txt file to the ZIP
                zip.AddEntry("README.txt", readMeMessage, Encoding.ASCII);
    
    
                // Send the contents of the ZIP back to the output stream
                //   zip.MaxOutputSegmentSize = 65536;
                zip.Save(Response.OutputStream);
                // int a=zip.NumberOfSegmentsForMostRecentSave;
                // txtZIPPassword.Text=a.ToString();
            }
    
            Response.Flush();
            HttpContext.Current.Response.End();
