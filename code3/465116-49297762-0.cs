        private void splitContainer1_Panel2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("FileDrop", false))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void splitContainer1_Panel2_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = new String[1];
            files[0] = @"C:\out.txt";
            //create a dataobject holding this array as a filedrop
            DataObject data = new DataObject(DataFormats.FileDrop, files);
            //also add the selection as textdata
            data.SetData(DataFormats.StringFormat, files[0]);
            //do the dragdrop
            DoDragDrop(data, DragDropEffects.Copy);
            if (e.Data.GetDataPresent("FileDrop", false))
            {
                string[] paths = (string[])(e.Data.GetData("FileDrop", false));
                foreach (string path in paths)
                {
                     // in this line you can have the paths to add attachements to the email
                    Console.WriteLine(path);
                }
            }
        }
