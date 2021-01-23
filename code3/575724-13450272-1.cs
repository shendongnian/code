    /******
    *	the terminus file format is weird
    *	basically it goes like this
    *		tmp/myfilename.ext.00000000001	4kB
    *		tmp/myfilename.ext.00000000002	4kB
    *		tmp/myfilename.ext.00000000003	4kB
    *		tmp/myfilename.ext.00000000004	4kB
    *		tmp/myfilename.ext.terminus		<=4kB
    *	this will re-built here to 
    *		dir/myfilename.ext				>16kB <20kB
    */
				
    class classActionType_clientPush : classActionType
    {
        string relpath = "";
        jsonFolder myFolder;
        jsonDomain myDomain;
        Queue<HTTPPoster> queue = new Queue<HTTPPoster>();
        /// <param name="relativeLocalFilePath">
        /// this "relativeLocalFilePath" refers to path RE: the ~localFolder~ - this class will cut the file and upload it in 4096kB chunks
        /// </param>
        /// <param name="folder">
        /// use this for the folder pathing
        /// </param>
        /// <param name="domain">
        /// this is for the credentials and the url
        /// </param>
        public void setPath(string relativeLocalFilePath, jsonFolder folder, jsonDomain domain)
        {
            string tmppath = folder.localFolder + relativeLocalFilePath;
            if (File.Exists(tmppath))
            {
                relpath = relativeLocalFilePath;
                myFolder = folder;
                myDomain = domain;
            }
            else
            {
                throw new Exception("classActionType_clientPull.setPath():tmppath \"" + tmppath + "\" does not already exist");
            }
        }
        public override void action()
        {
            if (relpath == "")
            {
                throw new Exception("classActionType_clientPull.action():relpath cannot be \"\"");
            }
            /***
             * split it into chunks and copy file to server
             */
            try
            {
                
                int bytesRead;
                int bufferSize = 4096;
                byte[] buffer = new byte[bufferSize];
                string filePath = myFolder.localFolder + relpath;
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    int i = 0;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        string postFileName = Path.GetFileName(filePath) + "." + i++.ToString().PadLeft(10, '0');
                        if (bytesRead < bufferSize)
                        {
                            postFileName = Path.GetFileName(filePath) + ".terminus";
                        }
                        HTTPPoster mypost = new HTTPPoster();
                        mypost.add(buffer);
                        mypost.setdomain(this.myDomain);
                        mypost.uploadedName(postFileName);
                        queue.Enqueue(mypost);
                        Debug.WriteLine("   nof: HTTPPoster.action() loop counter " + i + "");
                    }
                }
                
                do
                {
                    HTTPPoster Post = (HTTPPoster)queue.Dequeue();
                    Post.Run();
                } while (queue.Count != 0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("   nof: HTTPPoster.action() failed\r\n" + ex.Message + "\r\n" + ex.StackTrace);
            }
        }
    }
    class HTTPPoster
    {
        byte[] sendable;
        string filename;
        jsonDomain myDomain;
        public void add(byte[] b)
        {
            sendable = b;
        }
        public void uploadedName(string p)
        {
            filename = p;
        }
        public void setdomain(jsonDomain domain)
        {
            myDomain = domain;
        }
        public void Run()
        {
            try
            {
                /***
                 * this does the actual post (!gulp)
                 */ 
                string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
                byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(myDomain.url + "/io/clientPush.php");
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                wr.ContentType = "multipart/form-data; boundary=" + boundary;
                wr.Method = "POST";
                wr.KeepAlive = true;
                wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
                Stream rs = wr.GetRequestStream();
                string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                string formitem;
                byte[] formitembytes;
                classHasher hash = new classHasher();
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                formitem = string.Format(formdataTemplate, "username", myDomain.user);
                formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                formitem = string.Format(formdataTemplate, "password", hash.Decrypt(myDomain.password, "stephanoonooislovelyx"));
                formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
                string header = string.Format(headerTemplate, "file", filename, "multipart/mixed");
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                rs.Write(headerbytes, 0, headerbytes.Length);
                rs.Write(sendable, 0, 4096);
                byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                rs.Write(trailer, 0, trailer.Length);
                rs.Close();
                WebResponse wresp = null;
                try
                {
                    wresp = wr.GetResponse();
                    Stream myStream = wresp.GetResponseStream();
                    StreamReader myReader = new StreamReader(myStream);
                    Debug.WriteLine("   nof: HTTPPoster.Run() all ok \r\n" + myReader.ReadToEnd());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("   nof: HTTPPoster.Run() finished\r\n" + ex.Message + "\r\n" + ex.StackTrace);
                    if (wresp != null)
                    {
                        wresp.Close();
                        wresp = null;
                    }
                }
                finally
                {
                    wr = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("   nof: HTTPPoster.Run() !ERROR! \r\n" + ex.Message + "\r\n" + ex.StackTrace);               
            }
        }
    }
