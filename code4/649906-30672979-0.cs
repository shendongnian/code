    enter code herepublic static bool PausePrintJob(string printerName, int printJobID)
        {
            bool isActionPerformed = false;
            string searchQuery = "SELECT * FROM Win32_PrintJob";
            ManagementObjectSearcher searchPrintJobs = new ManagementObjectSearcher(searchQuery);
            ManagementObjectCollection prntJobCollection = searchPrintJobs.Get();
            foreach (ManagementObject prntJob in prntJobCollection)
            {
                System.String jobName = prntJob.Properties["Name"].Value.ToString();
            
                //Job name would be of the format [Printer name], [Job ID]
                char[] splitArr = new char[1];
                splitArr[0] = Convert.ToChar(",");
                string prnterName = jobName.Split(splitArr)[0];
                int prntJobID = Convert.ToInt32(jobName.Split(splitArr)[1]);
                string documentName = prntJob.Properties["Document"].Value.ToString();
                if (String.Compare(prnterName, printerName, true) == 0)
                {
                    if (prntJobID == printJobID)
                    {
                        // MessageBox.Show("PAGINAS : " + prntJob.Properties["TotalPages"].Value.ToString() + documentName + " " + prntJobID);
                        prntJob.InvokeMethod("Pause", null);
                        MessageBox.Show(prntJob.Properties["Color"].Value.ToString());
                        //prntJob.InvokeMethod("Resume", null);
                        isActionPerformed = true;
                        break;
                    }
                }## Heading ##
            }
            return isActionPerformed;
        }
