        var file = "test.pdf";
        var reader = new PdfReader(file);
        var streamBytes = reader.GetPageContent(2);
        var tokenizer = new PRTokeniser(new RandomAccessFileOrArray(streamBytes));
        var ps = new PdfContentParser(tokenizer);
        List<PdfObject> operands = new List<PdfObject>();
        while (ps.Parse(operands).Count > 0)
        {
            PdfLiteral oper = (PdfLiteral)operands[operands.Count - 1];
            var cmd = oper.ToString();
            switch (cmd)
            {
                case "q":
                    Console.WriteLine("SaveGraphicsState(); //q");
                    break;
                case "Q":
                    Console.WriteLine("RestoreGraphicsState(); //Q");
                    break;
  
               // good luck with the rest!
            }
        }
        
