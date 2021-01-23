    var data=@"column1,column2,column3,column4,column5
    ----------
    alex,p,22323,23232,hello
    mike,t,""121212,232323,4343434"",33432,hi
    guna,s,""2423,2332"",whats
    cena,a,34443,33432,up";
    using (var sr = new StringReader(data))
    using (var parser =
        new TextFieldParser(sr)
            {
                TextFieldType = FieldType.Delimited,
                Delimiters = new[] { "," },
    			CommentTokens = new[] { "--" }
            })
    {
        while (!parser.EndOfData)
        {
            string[] fields;
            fields = parser.ReadFields();
            //yummy
        }
    }
