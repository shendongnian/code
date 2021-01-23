    string path = Server.MapPath(@daoWordPuzzle.GetfileURL());
    
    foreach(string line in File.ReadLines(path))
    {
        Response.Write(line + " <br />");
    }
