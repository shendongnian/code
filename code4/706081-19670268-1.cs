                if (sProcessName.ToLower().Contains("wwahost") 
                && ((Environment.OSVersion.Version.Major == 6) && (Environment.OSVersion.Version.Minor > 1)))
                {
                    IntPtr ptrProcess = OpenProcess(QueryLimitedInformation, false, iPID);
                    if (IntPtr.Zero != ptrProcess)
                    {
                        uint cchLen = 128;
                        StringBuilder sbName = new StringBuilder((int)cchLen);
                        long lResult = GetApplicationUserModelId(ptrProcess, ref cchLen, sbName);
                        if (ERROR_SUCCESS == lResult)
                        {
                            sResult = sbName.ToString();
                        }
                        else if (ERROR_INSUFFICIENT_BUFFER == lResult)
                        {
                            sbName = new StringBuilder((int)cchLen);
                            if (ERROR_SUCCESS == GetApplicationUserModelId(ptrProcess, ref cchLen, sbName))
                            {
                                sResult = sbName.ToString();
                            }
                        }
                        CloseHandle(ptrProcess);
                    }
                }
