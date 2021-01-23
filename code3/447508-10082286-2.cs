    string filename = "salmnas dlajhdla kjha;dmas'lkasn";
    foreach (char c in Path.GetInvalidFileNameChars())
        filename = filename.Replace(System.Char.ToString(c), "");
    foreach (char c in Path.GetInvalidPathChars())
        filename = filename.Replace(System.Char.ToString(c), "");
