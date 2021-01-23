    private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            //display formats available
            this.label1.Text = "Formats:\n";
            foreach (string format in e.Data.GetFormats())
            {
                this.label1.Text += "    " + format + "\n";
            }
            //ensure FileGroupDescriptor is present before allowing drop
            if (e.Data.GetDataPresent("FileGroupDescriptor"))
            {
                e.Effect = DragDropEffects.All;
            }
        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            //wrap standard IDataObject in OutlookDataObject
            OutlookDataObject dataObject = new OutlookDataObject(e.Data);
            //get the names and data streams of the files dropped
            string[] filenames = (string[])dataObject.GetData("FileGroupDescriptorW");
            MemoryStream[] filestreams = (MemoryStream[])dataObject.GetData("FileContents");
            this.label1.Text += "Files:\n";
            for (int fileIndex = 0; fileIndex < filenames.Length; fileIndex++)
            {
                //use the fileindex to get the name and data stream
                string filename = filenames[fileIndex];
                MemoryStream filestream = filestreams[fileIndex];
                this.label1.Text += "    " + filename + "\n";
                //save the file stream using its name to the application path
                FileStream outputStream = File.Create(filename);
                filestream.WriteTo(outputStream);
                outputStream.Close();
            }
        }
