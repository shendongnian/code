//After creating dropbox service use the following code 
//Following code searches the root folder, file of type "all" including subfolders
//To search a particular folder write the path in the first parameter of SearchAsync Method
//To list only "txt" files write ".txt" for the second parameter
    dropbox.SearchAsync("", ".").ContinueWith(task =>
    {                    
    Console.WriteLine(task.Result.Count);
        foreach (Entry file in task.Result)
        {
              Console.WriteLine(file.Path); //prints path
        }
    }); 
</pre>
