        /// <summary>
        /// Gets all images inside a Folder
        /// and triggers OCR on each..
        /// </summary>
        /// <param name="directoryPath"> Path to Folder </param>
        /// <returns> Text </returns>        
        public string CheckFileAndDoOCR(string directoryPath)
        {
            string TheTxt = "";
            IEnumerator files = Directory.GetFiles(directoryPath).GetEnumerator();
            
            while (files.MoveNext())
            {
                // FileInfo
                FileInfo foo = new FileInfo(Convert.ToString(files.Current));
                // Check for JPG File Format
                if (foo.Extension == ".jpg" || foo.Extension == ".JPG")
                // or // ImageFormat.Jpeg.ToString()
                {
                    // Start OCR Procedure
                    TheTxt = DoOCR(foo.FullName);
                    // Create TXT file next to ImageFile
                    string txtFileName = foo.DirectoryName + "\\" + foo.Name.Replace(foo.Extension,"") + ".txt";
                    FileStream createFile = new FileStream(txtFileName, FileMode.OpenOrCreate);
                    // Save the text in to TXT file
                    StreamWriter writeFile = new StreamWriter(createFile);
                    writeFile.Write(TheTxt);
                    // Close
                    writeFile.Close();
                    createFile.Close();
                }
                // Delete used pictures (Optional)
                /*--------------------------------------------------------------------*/
                try 
                { foo.Delete(); }
                catch (Exception ex)
                { Logger(LogPath, "| Exception: Source[" + ex.Source + "] Message[" + ex.Message + 
                    "] InnerException[" + ex.InnerException + "] StackTrace[" + ex.StackTrace + "] | "); }
                /*--------------------------------------------------------------------*/
            }
            return TheTxt;
        }
        // DoOCR
        // 
        /// <summary>
        /// Start an OCR scan on given ImageFile
        /// </summary>
        /// <param name="FullPath"> Path to ImageFile </param>
        /// <returns> Text </returns>
        public string DoOCR(string FullPath)
        {
            string txt;
            // OCR Operations...
            MODI.Document md = new MODI.Document(); // Create MODI.Document
            md.Create(FullPath); // Fill MODI.Document with my file
            // Showprogress of OCR
            md.OnOCRProgress += new MODI._IDocumentEvents_OnOCRProgressEventHandler(this.ShowProgress);
            // Begin OCR
            md.OCR(MODI.MiLANGUAGES.miLANG_ENGLISH, false, false); // OCR();
            // Image from file
            MODI.Image image = (MODI.Image)md.Images[0];
            txt = image.Layout.Text;
            // Optionally you can get only first word by using word.Text
            /// Words from Image :
            // MODI.Word word = image.Layout.Words[0];
            /// Text from first Word :
            // txt = word.Text;
            
            // Close OCR
            word = null;
            image = null;
            md.Close(false);
            md = null;
            // Finalize
            GC.Collect();
            GC.WaitForPendingFinalizers();
            // Return Text
            return txt;
        }
