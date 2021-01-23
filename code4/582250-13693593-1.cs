            const int VER_NT_WORKSTATION = 1;
            var osInfoEx = new OsVersionInfoEx();
            osInfoEx.dwOSVersionInfoSize = Marshal.SizeOf(osInfoEx);
            try
            {
                if (!GetVersionEx(ref osInfoEx))
                {
                    throw(new Exception("Could not determine OS Version"));
                    
                }
                if (osInfoEx.dwMajorVersion == 6 && osInfoEx.dwMinorVersion == 2 
                    && osInfoEx.wProductType == VER_NT_WORKSTATION)
                    MessageBox.Show("You've Got windows 8");
            }
            catch (Exception)
            {
                
                throw;
            }
