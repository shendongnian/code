    string bytePath = resPath + themesIni;
        
    if (!File.Exists(bytePath))
    {
        if (foundRow != null) bytePath = resPath + @"\" + foundRow.ItemArray[1] + @"\" + themesIni;
    }
    byte[] arr = File.ReadAllBytes(bytePath);
    string fileAsString = new UnicodeEncoding().GetString(arr);
    StringReader str = new StringReader(fileAsString);
    string line;
    Type curType = null;
    Type parentType = null;
    while ((line = str.ReadLine()) != null)
    {
        if (string.IsNullOrEmpty(line) | line.StartsWith(";")) continue;
        if (line.Contains('['))
        {
            line = (line[0] + line[1].ToString().ToUpper() + line.Substring(2))
                .Trim('[').Trim(']').Trim(')').Replace("(", "_").Replace("::", "Ext").Trim();
            string[] splitLines = line.Split('.');
            //splitLines[0] = 
            //    (splitLines[0][0] + splitLines[0][1].ToString().ToUpper() + splitLines[0].Substring(2))
            //    .Trim('[').Trim(']').Trim(')').Replace("(", "_").Replace("::", "Ext").Trim();
            //splitLines[1] = 
            //    (splitLines[1][0] + splitLines[1][1].ToString().ToUpper() + splitLines[1].Substring(2))
            //    .Trim('[').Trim(']').Trim(')').Replace("(", "_").Replace("::", "Ext").Trim();
            if (splitLines.Length > 1)
            {
                if (parentType == null)
                {
                    parentType = typeof(Parameters).GetNestedTypes().ToList()
                        .Find(tipe => tipe.Name == splitLines[0]);
                    List<Type> listing = parentType.GetNestedTypes().ToList();
                    curType = listing.Find(tipe => tipe.Name == splitLines[1]);
                }
                else
                {
                    List<Type> listing = parentType.GetNestedTypes().ToList();
                    curType = listing.Find(tipe => tipe.Name == splitLines[1]);
                }
            }
            else
            {
                parentType = null;
                List<Type> listing = typeof (Parameters).GetNestedTypes().ToList();
                string lineT = line;
                Type listingOf = listing.Find(tipe => tipe.Name == lineT);
                curType = listingOf;
            }
        }
        else
        {
            string[] splits = line.Split('=');
            splits[0] = splits[0].Substring(0, 1).ToUpper() + splits[0].Substring(1);
            if (curType != null)
            {
                FieldInfo found = curType.GetField(splits[0].Trim(')').Replace("(", "_").Trim());
                if (found != null)
                    found.SetValue(null, splits[1].Trim());
            }
        }
    }
