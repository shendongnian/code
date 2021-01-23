        public static bool execCmd(string sFunc, string sArg, ref string sResponse)
        {
            bool bRet = true;
            try
            {
                // Instantiate this class
                myCommands cmbn = new myCommands(sFunc, sArg);
                // Get the desired method by name: DisplayName
                //MethodInfo methodInfo = typeof(CallMethodByName).GetMethod("DisplayName");
                MethodInfo methodInfo = typeof(myCommands).GetMethod(sFunc);
                // Use the instance to call the method without arguments
                methodInfo.Invoke(cmbn, null);
                sResponse = cmbn.response;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in execCmd for '" + sFunc + "' and '" + sArg + "' " + ex.Message); 
                bRet = false; 
            }
            return bRet;
        }
