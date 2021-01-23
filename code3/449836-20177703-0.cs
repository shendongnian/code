    var reader = new PdfReader(fileName);
    StringBuilder sb = new StringBuilder();
    try
    {
        for (int page = 1; page <= reader.NumberOfPages; page++)
        {
            var cpage = reader.GetPageN(page);
            var content = cpage.Get(PdfName.CONTENTS);
            var ir = (PRIndirectReference)content;
            var value = reader.GetPdfObject(ir.Number);
            if (value.IsStream())
            {
                PRStream stream = (PRStream)value;
                var streamBytes = PdfReader.GetStreamBytes(stream);
                var tokenizer = new PRTokeniser(new RandomAccessFileOrArray(streamBytes));
                try
                {
                    while (tokenizer.NextToken())
                    {
                        if (tokenizer.TokenType == PRTokeniser.TK_STRING)
                        {
                            string str = tokenizer.StringValue;
                            sb.Append(str);
                        }
                    }
                }
                finally
                {
                    tokenizer.Close();
                }
            }
        }
    }
    finally
    {
        reader.Close();
    }
    return sb.ToString();
