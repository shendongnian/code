            int numFiles = Convert.ToInt32(Dts.Variables["numFiles"].Value.ToString());
            switch (numFiles)
            {
                case 0:
                    //MessageBox.Show("Error: No files are in the directory C:\\Directory1\n Please restart execution.");
                    Dts.Events.FireError(0, "File count", "Error: No files are in the directory C:\\Directory1\n Please restart execution.", string.Empty, 0);
                    break;
                case 1:
                    //MessageBox.Show("Error: Only one file was found in the directory C:\\Directory1\n Please restart execution.");
                    Dts.Events.FireError(0, "File count", "Error: Only one file was found in the directory C:\\Directory1\n Please restart execution.", string.Empty, 0);
                    break;
                case 2:
                    //MessageBox.Show("Warning: Only two files have been loaded into the directory C:\\Directory1\n Is this intended?.");
                    Dts.Events.FireWarning(0, "File count", "Warning: Only two files have been loaded into the directory C:\\Directory1\n Is this intended?.", string.Empty, 0);
                    break;
            }
