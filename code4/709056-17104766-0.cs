    public void SaveFile_Click(object sender, EventArgs e) 
    {
       using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\YourFile.ini"))
       {
           foreach (var item in list_selected.Items)
           {
             file.WriteLine(item.ToString());
           }
       }
    }
