        private string[,] GetImagesFromServerFolder()
        {
            IntPtr token;
            if (
                !NativeMethods.LogonUser(GlobalVar.ServerLoginName, GlobalVar.ServerLocation,
                                         GlobalVar.ServerLoginPassword, NativeMethods.LogonType.NewCredentials,
                                         NativeMethods.LogonProvider.Default, out token))
            {
                throw new Win32Exception();
            }
            try
            {
                IntPtr tokenDuplicate;
                if (!NativeMethods.DuplicateToken(
                    token,
                    NativeMethods.SecurityImpersonationLevel.Impersonation,
                    out tokenDuplicate))
                {
                    throw new Win32Exception();
                }
                try
                {
                    using (WindowsImpersonationContext impersonationContext =
                        new WindowsIdentity(tokenDuplicate).Impersonate())
                    {
                        /******************* CODE FROM HERE *******************/
                        List<string> files = new List<string>(Directory.GetFiles(_PHYSICAL SERVER LOCATION_));
                        string[,] fullDetails = new string[files.Count,2];
                        int[] counter = {0};
                        foreach (var file in files)
                        {
                            foreach (var databaseImage in listDatabaseImages.Items)
                            {
                                if (file.Remove(0, 56).Trim().ToUpper().Replace(".PDF", ".jpg") ==
                                    databaseImage.ToString())
                                {
                                    DateTime creationTime = File.GetLastWriteTime(file);
                                    fullDetails[counter[0], 0] = file.Remove(0, 56).Trim().ToUpper().Replace(".PDF", ".pdf");
                                    fullDetails[counter[0], 1] = creationTime.ToString();
                                    //string FullFileName = filePaths[s, 0].Remove(0, 56).Trim().ToUpper().Replace(".PDF", ".pdf");
                                    if (listServerImages.InvokeRequired)
                                    {
                                        listDatabaseImages.Invoke(
                                            new MethodInvoker(
                                                () =>
                                                    {
                                                        if (file != null)
                                                            listServerImages.Items.Add(
                                                                file.Remove(0, 56).Trim().ToUpper().Replace(".JPG", ".jpg"));
                                                    }));
                                        //Add the file name to a List to View
                                    }
                                    counter[0] = counter[0] + 1;
                                    if (lblServerImages.InvokeRequired)
                                    {
                                        lblServerImages.Invoke(
                                            new MethodInvoker(() => lblServerImages.Text = "Server Images: " + counter[0]));
                                    }
                                }
                            }
                        }
                        arraySize = counter[0];
                        impersonationContext.Undo(); //leave this here
                        return fullDetails;
                        /******************* CODE TO HERE *******************/
                    }
                }
                finally
                {
                    if (tokenDuplicate != IntPtr.Zero)
                    {
                        if (!NativeMethods.CloseHandle(tokenDuplicate))
                        {
                            // Uncomment if you need to know this case.
                            ////throw new Win32Exception();
                        }
                    }
                }
            }
            finally
            {
                if (token != IntPtr.Zero)
                {
                    if (!NativeMethods.CloseHandle(token))
                    {
                        // Uncomment if you need to know this case.
                        ////throw new Win32Exception();
                    }
                }
            }
        }  
