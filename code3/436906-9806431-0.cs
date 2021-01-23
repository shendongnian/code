    for (int i = 0; i < splitFieldnames.Length; i++)
    {
        string fieldName = splitFieldnames[i];
        for (int j = 0; j < splitDatatypeNames.Length; j++)
        { 
            string dataType = splitDatatypeNames[j];
            for (int k = 0; k < SplitControlNames.Length; k++)
            { 
                string controlName = SplitControlNames[k];
                for (int l = 0; l < splitControlTypeNames.Length; l++)
                {
                    string controlType = splitControlTypeNames[l];
                    if (i == j && j == k && k == l)
                    { 
                        if (controlType == "textbox" && dataType == "string")
                        { 
                            Response.Write("_Student." + fieldName + "= " + controlName + ".Text;");
                            break;
                        }
                    }
                }
            }
        }
    }
