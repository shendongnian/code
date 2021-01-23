    public class AsyncCopy
        {
            public delegate void CopyDelegate(string sourceFile, string destFile);
    
            public static void AsynFileCopy(string sourceFile, string destFile)
            {
                CopyDelegate del = new CopyDelegate(FileCopy);
                IAsyncResult result = del.BeginInvoke(sourceFile, destFile, CallBackAfterFileCopied, null);
            }
    
            public static void FileCopy(string sourceFile, string destFile)
            { 
                // Add here your code for copy
            }
    
            public static void CallBackAfterFileCopied(IAsyncResult result)
            {
                // Add here your callback logic
            }
        }
