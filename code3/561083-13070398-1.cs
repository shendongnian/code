    private void DisplayPhoto()
    {
		// make sure the file is JPEG or GIF
                    System.IO.FileInfo testFile = new System.IO.FileInfo(myFile);
		// Create a new stream to load this photo into
                    FileStream myFileStream = new FileStream(myFile, FileMode.Open, FileAccess.Read);
		// Create a buffer to hold the stream of bytes
                    photo = new byte[myFileStream.Length];
                    // Read the bytes from this stream and put it into the image buffer
                    myStream.Read(photo, 0, (int)myFileStream.Length);
                    // Close the stream
                    myFileStream.Close();
 		// Create a new MemoryStream and write all the information from
                // the byte array into the stream
                MemoryStream myStream = new MemoryStream(photo, true);
                myStream.Write(photo, 0, photo.Length);
                // Use the MemoryStream to create the new BitMap object
                Bitmap FinalImage = new Bitmap(myStream);
                upicPhoto.Image = ImageManipulation.ResizeImage(
                                                    FinalImage,
                                                    upicPhoto.Width,
                                                    upicPhoto.Height,
                                                    true);
                // Close the stream
                myStream.Close();
    }
