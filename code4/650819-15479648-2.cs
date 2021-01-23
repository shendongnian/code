            protected void btnShow_Click(object sender, EventArgs e)
            {
             ShowData();
            }
            public void ShowData()
            {
                DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath(""));
                
                FileInfo[] info = dirInfo.GetFiles("*.zip");            //Get FileInfo and Save it a FileInfo[] Array
    
                List<Getfiles> _items = new List<Getfiles>();          // Define a List with Two coloums
    
                foreach (FileInfo file in info) //Loop the FileInfo[] Array
                   _items.Add(new Getfiles { Name = file.Name, LastWriteTime = file.LastWriteTime.ToString("MM/dd/yyyy") });  // Save the Name and LastwriteTime to List
                
               //you can use Any one the Filtered list from the below...
                var tlistFiltered = _items.Where(item => item.Name == "FilterValue"); // Find the File by their File Name
                var tlistFiltered1 = _items.Where(item => item.Name.Contains("FilterValue")); // Find the file that Contains Specific word in its File Name
                var tlistFiltered2 = _items.Where(item => item.Name.StartsWith("FilterValue"));// Find tha File that StartsWith Some Specific Word
    
    
                articleList.DataSource = tlistFiltered; //Assign the DataSource to DataGrid
                articleList.DataBind();
    
            }
    
            public class Getfiles
            {
                public string Name { get; set; }
                public string LastWriteTime { get; set; }
            }
