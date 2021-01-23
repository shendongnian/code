        static bool isProtected(object filePath)
        {
            Application myapp = new Application();
            object pw = "thispassword";
            try
            {
                // Trying this for Word document
                myapp.Documents.Open(ref filePath, PasswordDocument: ref pw); // try open
                myapp.Documents[ref filePath].Close();  // close it if it does open    
            }
            catch (COMException ex)
            {
                if (ex.HResult == -2146822880) // Can't Open Doc Caused By Invalid Password
                    return true;
                else
                    Console.WriteLine(ex.Message + "  " + ex.HResult);  // For debugging, have only tested this one document.
            }
            return false;
        }
