    public class DisplayImage : IHttpHandler
    {
        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler" /> interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext" /> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
        public void ProcessRequest(HttpContext context)
        {
            if (!this.HasAccess())
            {
                context.Response.End();
                return;
            }
            string requestFileName = context.Request.QueryString["FileName"];
            DecryptFile(requestFileName, context);
        }
        /// <summary>
        /// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler" /> instance.
        /// </summary>
        /// <value><c>true</c> if this instance is reusable; otherwise, <c>false</c>.</value>
        /// <returns>true if the <see cref="T:System.Web.IHttpHandler" /> instance is reusable; otherwise, false.</returns>
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// Determines whether the user has access to display an image.
        /// </summary>
        /// <returns><c>true</c> if this instance has access; otherwise, <c>false</c>.</returns>
        private bool HasAccess()
        {
            // Check if user is logged in and has permissions
            // to do the decryption
            // use your own logic here
            return true;
        }
        /// <summary>
        /// Decrypts the file and outputs to the response buffer
        /// </summary>
        /// <param name="inputFile">The input file.</param>
        /// <param name="context">The context.</param>
        private void DecryptFile(string inputFile, HttpContext context)
        {
            if (PathTraversalCheck(inputFile))
            {
                context.Response.End();
                return;
            }
            // get the base directory
            inputFile = Path.Combine(ConfigurationManager.AppSettings["filedirectory"], inputFile);
            if (!File.Exists())
            {
                context.Response.End();
                return;
            }
            string password = @"myKey123"; // Your Key Here
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);
            using (FileStream encryptedFile = new FileStream(inputFile, FileMode.Open))
            {
                RijndaelManaged rijndael = new RijndaelManaged();
                using (MemoryStream output = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(encryptedFile, rijndael.CreateDecryptor(key, key), CryptoStreamMode.Read))
                    {
                        // write to the memory stream
                        var buffer = new byte[1024];
                        var read = cryptoStream.Read(buffer, 0, buffer.Length);
                        while (read > 0)
                        {
                            output.Write(buffer, 0, read);
                            read = cryptoStream.Read(buffer, 0, buffer.Length);
                        }
                        cryptoStream.Flush();
                        // output to the response buffer
                        context.Response.ContentType = "image/jpeg";
                        context.Response.BinaryWrite(output.ToArray());
                    }
                }
            }
        }
        /// <summary>
        /// Checks for a path traversal attack
        /// </summary>
        /// <param name="inputFile">The input file.</param>
        /// <returns>System.String.</returns>
        private bool PathTraversalCheck(string inputFile)
        {
            if (inputFile.Contains(".") || inputFile.Contains('\\') || inputFile.Contains('/'))
            {
                return true;
            }
            return false;
        }
    }
