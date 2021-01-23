    public static bool DeleteTiffTags(string sFileName, List<ushort> ushortTagNumbers)
    {
        //Deletes a list of tiff tag from the given image
        //Returns true if successful or false if error occured
         //Define variables
        List<TIFFTAGS_PAGE> ttPage = new List<TIFFTAGS_PAGE>();
         //Check for empty list
        if (ushortTagNumbers.Count == 0) return false;
         try
        {
            //ADDED
            m_lTagsToWrite = new List<TIFFTAGS_TAG>();
            m_lTagsToWrite.Add(new TIFFTAGS_TAG("", 38001, Convert.ToString("")));
            m_lTagsToWrite.Add(new TIFFTAGS_TAG("", 38002, Convert.ToString("")));
            m_parentExtender = Tiff.SetTagExtender(TagExtender);
             //Open the file for reading
            using (Tiff input = Tiff.Open(sFileName, "r"))
            {
                if (input == null) return false;
                 //Get page count
                int numberOfDirectories = input.NumberOfDirectories();
                 //Go through all the pages
                for (short i = 0; i < numberOfDirectories; ++i)
                {
                    //Set the page
                    input.SetDirectory(i);
                     //Create a new tags dictionary to store all my tags
                    Dictionary<ushort, FieldValue[]> dTags = new Dictionary<ushort, FieldValue[]>();
                     //Get all the tags for the page
                    for (ushort t = ushort.MinValue; t < ushort.MaxValue; ++t)
                    {
                        TiffTag tag = (TiffTag)t;
                        FieldValue[] tagValue = input.GetField(tag);
                        if (tagValue != null)
                        {
                            dTags.Add(t, tagValue);
                        }
                    }
                     //Check if the page is encoded
                    bool encoded = false;
                    FieldValue[] compressionTagValue = input.GetField(TiffTag.COMPRESSION);
                    if (compressionTagValue != null)
                        encoded = (compressionTagValue[0].ToInt() != (int)Compression.NONE);
                    
                    //Create a new byte array to store all my image data
                    int numberOfStrips = input.NumberOfStrips();
                    byte[] byteImageData = new byte[numberOfStrips * input.StripSize()];
                    int offset = 0;
                     //Get all the image data for the page
                    for (int n = 0; n < numberOfStrips; ++n)
                    {
                        int bytesRead;
                        if (encoded)
                            bytesRead = input.ReadEncodedStrip(n, byteImageData, offset, byteImageData.Length - offset);
                        else
                            bytesRead = input.ReadRawStrip(n, byteImageData, offset, byteImageData.Length - offset);
                         //Add to the offset keeping up with where we are
                        offset += bytesRead;
                    }
                     //Save all the tags, image data, and height, etc for the page
                    TIFFTAGS_PAGE tiffPage = new TIFFTAGS_PAGE();
                    tiffPage.Height = input.GetField(TiffTag.IMAGELENGTH)[0].ToInt();
                    tiffPage.Tags = dTags;
                    tiffPage.PageData = byteImageData;
                    tiffPage.Encoded = encoded;
                    tiffPage.StripSize = input.StripSize();
                    tiffPage.StripOffset = input.GetField(TiffTag.STRIPOFFSETS)[0].ToIntArray()[0];
                    ttPage.Add(tiffPage);
                }
            }
             //Open the file for writing
            using (Tiff output = Tiff.Open(sFileName + "-new.tif", "w"))
            {
                if (output == null) return false;
                 //Go through all the pages
                for (short i = 0; i < ttPage.Count(); ++i)
                {
                    //Write all the tags for the page
                    foreach (KeyValuePair<ushort, FieldValue[]> tagValue in ttPage[i].Tags)
                    {
                        //Write all the tags except the one's needing to be deleted
                        if (!ushortTagNumbers.Contains(tagValue.Key))
                        {
                            TiffTag tag = (TiffTag)tagValue.Key;
                            output.GetTagMethods().SetField(output, tag, tagValue.Value);
                        }
                    }
                     //Set the height for the page
                    output.SetField(TiffTag.ROWSPERSTRIP, ttPage[i].Height);
                     //Set the offset for the page
                    output.SetField(TiffTag.STRIPOFFSETS, ttPage[i].StripOffset);
                     //Save page data along with tags
                    output.CheckpointDirectory();
                     //Write each strip one at a time using the same orginal strip size
                    int numberOfStrips = ttPage[i].PageData.Length / ttPage[i].StripSize;
                    int offset = 0;
                    for (int n = 0; n < numberOfStrips; ++n)
                    {
                        //Write all the image data (strips) for the page
                        if (ttPage[i].Encoded)
                            //output.WriteEncodedStrip(n, byteStrip, offset, byteStrip.Length - offset);
                            output.WriteEncodedStrip(0, ttPage[i].PageData, offset, ttPage[i].StripSize - offset);
                        else
                            output.WriteRawStrip(n, ttPage[i].PageData, offset, ttPage[i].StripSize - offset);
                         //Add to the offset keeping up with where we are
                        offset += ttPage[i].StripOffset;
                    }
                     //Save the image page
                    output.WriteDirectory();
                }
            }
             //ADDED
            Tiff.SetTagExtender(m_parentExtender);
        }
        catch
        {
            //ADDED
            Tiff.SetTagExtender(m_parentExtender);
            
            //Error occured
            return false;
        }
         //Return success
        return true;
    }
