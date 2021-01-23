    protected void DiasShow()     
    {
        var getFiles = Directory.GetFiles(HttpContext.Current.Server.MapPath("/CSS/Design/Page_Design/Dias/1920x1080/")); //Find alle filer I en mappe     
        
        var random = RandomiseList(getFiles);
        var txt = string.Empty;
        foreach (var randomFileName in random)
        {
            var imageName = System.IO.Path.GetFileNameWithoutExtension(randomFileName); 
            var fileType = System.IO.Path.GetExtension(randomFileName).ToUpper(); 
 
            if ((fileType == ".JPG") || (fileType == "JPEG")) 
            {
               txt += "<img src=\"CSS/Design/Page_Design/Dias/1920x1080/" + imageName+ "\" />";
            }
        }
        lbl_Dias.Text += txt;
     }
     public static T[] RandomiseList<T>(T[] source)
     {
         var rand = new Random(); //no need for own seed
         var list = new List<T>(source); //copy to a new list which we can remove from
         var result = new T[source.Length];
         for (int i = 0; i < source.Length; i++)
         {
             var listIndex = rand.Next(list.Count());
             result[i]= list[listIndex];
             list.RemoveAt(listIndex);
         }
         return result;
     }
