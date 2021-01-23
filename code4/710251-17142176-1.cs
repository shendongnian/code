     private void WriteToFile(string strPath, ref byte[] Buffer)
        {
            // Create a file
            System.IO.FileStream newFile = new System.IO.FileStream(strPath, System.IO.FileMode.Create);
            // Write data to the file
            newFile.Write(Buffer, 0, Buffer.Length);
            // Close file
            newFile.Close();
        }
