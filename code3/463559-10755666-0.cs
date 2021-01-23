           /// <summary>
        /// Gets a list of files on the CF Card. If dest is given, downloads them
        /// </summary>
        /// <param name="dest">string.empty if you just want a list of file names, otherwise the folder in which you want the files</param>
        /// <returns>a list of file names</returns>
        public  List<string> GetPicturesOnCard(string dest)
        {
            IntPtr volumeRef = IntPtr.Zero;
            IntPtr dirRef = IntPtr.Zero;
            IntPtr subDirRef = IntPtr.Zero;
            List<string> result = new List<string>();
            try
            {
                openSession();
                int nFiles;
                if (EDSDK.EdsGetChildAtIndex(camera, 0, out volumeRef) != EDSDK.EDS_ERR_OK)
                    throw new CannonException("Couldn't access Memory Card");
                //first child is DCIM
                if (EDSDK.EdsGetChildAtIndex(volumeRef, 0, out dirRef) != EDSDK.EDS_ERR_OK)
                    throw new CannonException("Memory Card formatting Error");
               //first child of DCIM has the actual photos
                if(EDSDK.EdsGetChildAtIndex(dirRef, 0, out subDirRef)!= EDSDK.EDS_ERR_OK)
                    throw new CannonException("Memory Card formatting Error");
                EDSDK.EdsGetChildCount(subDirRef, out nFiles);  
                for (int i = 0; i < nFiles; i++)
                {      
                   
                    IntPtr fileRef = IntPtr.Zero;
                    EDSDK.EdsDirectoryItemInfo fileInfo;
                    try
                    {
                        EDSDK.EdsGetChildAtIndex(subDirRef, i, out fileRef);
                        EDSDK.EdsGetDirectoryItemInfo(fileRef, out fileInfo);
                        if (dest != string.Empty)
                        {
                            IntPtr fStream = IntPtr.Zero;//it's a cannon sdk file stream, not a managed stream
                            uint fSize = fileInfo.Size;
                            try
                            {
                                EDSDK.EdsCreateMemoryStream(fSize, out fStream);
                                if (EDSDK.EdsDownload(fileRef, fSize, fStream) != EDSDK.EDS_ERR_OK)
                                    throw new CannonException("Image Download failed");
                                if (EDSDK.EdsDownloadComplete(fileRef) != EDSDK.EDS_ERR_OK)
                                    throw new CannonException("Image Download failed to complete");
                                byte[] buffer = new byte[fSize];
                                IntPtr imgLocation;
                                if (EDSDK.EdsGetPointer(fStream, out imgLocation) == EDSDK.EDS_ERR_OK)
                                {
                                    Marshal.Copy(imgLocation, buffer, 0, (int)fSize - 1);
                                    File.WriteAllBytes(dest + fileInfo.szFileName, buffer);
                                }
                                else
                                    throw new CannonException("Interal Error #1");//because the expection text coud land up in a message box some where
                            }
                            finally
                            {
                                EDSDK.EdsRelease(fStream);
                            }
                        }
                    }
                    finally
                    {
                        EDSDK.EdsRelease(fileRef);
                    }
                    result.Add(fileInfo.szFileName);
                }
            }
            finally
            {
                EDSDK.EdsRelease(subDirRef);
                EDSDK.EdsRelease(dirRef);
                EDSDK.EdsRelease(volumeRef);
                closeSession();
            }
            return result;
        }
    
