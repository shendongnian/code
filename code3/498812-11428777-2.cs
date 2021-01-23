        public static void OFDMethod(out string selectedFilename)
        {
           using( var ofd = new OpenFileDialog() )
           {   
               ofd.Filter = "Image files|*.jpg;*.jpeg;*.png;*.gif";
               if( ofd.ShowDialog() == DialogResult.OK )
               {
                   selectedFilename = ofd.Filename;
               }
               else
               {
                    selectedFilename = string.Empty;
               }
           }
        }
