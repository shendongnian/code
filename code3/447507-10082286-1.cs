    string filename = "salmnas dlajhdla kjha;dmas'lkasn";
    foreach(string c in System.IO.Path.GetInvalidFileNameChars)
        filename = filename.Replace(c, "")
    foreach(string c in System.IO.Path.GetInvalidPathChars)
        filename = filename.Replace(c, "")
