    var str = "'2014' , '381' , '1' , 'Eastern 10' , 'Wes 10' , '1'";
    var parts = str.Split(new string[] { " , " }, StringSplitOptions.None);
    
    parts[0] = String.Format("'{0}{1}'", parts[0].Replace("'", ""),
                                         parts[1].Replace("'", ""));
    str = String.Join(" , ", parts);
