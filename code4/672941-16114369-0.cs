      public class items
            {
                public string itemName { get; set; }
                public string itemSize { get; set; }
    
            }
    
            List<string> test = new List<string>();
    
            public void Window_DragDrop(object sender, DragEventArgs e)
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                List<string> fileList = new List<string>(files);
    
                foreach (string file in fileList)
                {
                    FileInfo fi = new FileInfo(file);
                    Console.WriteLine(fi.Name);
                    long byteSize = fi.Length;
                    string stringSize = BytesToString(byteSize);
                    string name = fi.Name;
                    scanQueue.Items.Add(new { itemName = name, itemSize = stringSize });
                }
                fileList.Clear();
            }
