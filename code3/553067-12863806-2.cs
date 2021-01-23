    Color c = Color.Aquamarine;
    // Or if you have R-G-B values:  Color c = Color.FromArgb(111,222,333);
    int argb = c.ToArgb(); // --> -8388652
    string s = argb.ToString(); // --> "-8388652"
    // Backwards
    argb = Int32.Parse(s);
    c = Color.FromArgb(argb);
 
    int R = c.R;
    int G = c.G;
    int B = c.B;
