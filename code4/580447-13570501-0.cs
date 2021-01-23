    private string title(string pth) //I'm passing a path
    {
      pth = System.IO.Path.GetFileNameWithoutExtension(pth);
      var indexOfDash = pth.IndexOf('-') + 1; // Add this line
      return pth.Substring(indexOfDash, pth.Length - indexOfDash).Trim();
    }
