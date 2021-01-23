    string nfar = "";
    var far = File.ReadAllText("paths.js");
    bool neg = false;
    string ccc = "";
    for(int i = 0; i < far.Length; i++)
    {
        char c = far[i];
        if (Char.IsDigit(c) || c == '.')
        {
            ccc += c;
            if (far[i + 1] == ' ' || far[i + 1] == ',')
            {
                ccc = neg ? "-" + ccc : ccc;
                float di;
                if (float.TryParse(ccc, out di))
                {
                    nfar += (di*0.75f).ToString();
                    ccc = "";
                    neg = false;
                }
            }
        }
        else if (c == '-')
        {
            neg = true;
        }
        else
        {
            nfar += c;
        }
    }
    File.WriteAllText("nfile.js", nfar);
