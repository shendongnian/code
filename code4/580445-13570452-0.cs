    private string title(string pth) //I'm passing a path
        {
            pth = System.IO.Path.GetFileNameWithoutExtension(pth); // I need an exact filename with no extension
            string retStr = string.Empty;
            if(pth.IndexOf('-')<pth.Length-1)
            {
                  retStr = pth.Substring(pth.IndexOf('-')+1).Trim(); // trying to return everything after '-'
            }
            return retStr;
        }
