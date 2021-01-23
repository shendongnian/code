        public class ReadDocumentEventArgs : EventArgs
        {
            public string ImageInfo { get; set; }
        }
        
        public void ReadDocument(object sender, ReadDocumentEventArgs ea)
        {
            // do whatever you need to do
            MessageBox.Show(ea.ImageInfo);  // example
        }
        private void link1add_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PictureBox imageCtrl = sender as PictureBox;
                
                // get the information you need to get from your control to identify it
                string imgInfo = "Hello, World!"; // example
                ContextMenu cm = new ContextMenu();
                cm.MenuItems.Add("Item 1");
                cm.MenuItems.Add("Item 2", 
                   (EventHandler)((s, rde) => 
                   { ReadDocument(s, new ReadDocumentEventArgs() 
                      { ImageInfo = imgInfo }); 
                   }));
                link1add.ContextMenu = cm;
            }
        }
