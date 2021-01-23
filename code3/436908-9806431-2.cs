    for (int i = 0; i < splitFieldnames.Length; i++)
    {
        if (splitControlTypeNames[i] == "textbox" && splitDatatypeNames[i] == "string")
        { 
            Response.Write("_Student." + splitFieldnames[i] + "= " + SplitControlNames[i] + ".Text;");
            break;
        }
    }
