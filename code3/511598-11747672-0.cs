    object lockObj = new object();
    
            private void copy_to_clipboard()
            {
                lock (lockObj)
    	        {
    		        if (pictureBox1.Image != null)
                        {
                            using (MemoryStream stream = new MemoryStream())
                            {
                                clipboardStatus.Text = "Copying image to clipboard...";                            
                                pictureBox1.Image.Save(stream, ImageFormat.Png);
                                var data = new DataObject("PNG", stream);
                                Clipboard.Clear();
                                Clipboard.SetDataObject(data, true);                            
                                clipboardStatus.Text = "Copied successfully!";
                            }
                        } 
    	        }
            }
