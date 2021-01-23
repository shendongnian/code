    public static string includer(string filename) 
    {
            string content = System.IO.File.ReadAllText(filename);
            return content;
    }
    includer(Server.MapPath("./" + filename));
