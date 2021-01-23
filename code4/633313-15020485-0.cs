    class Program
    {
        static void Main(string[] args)
        {
            Stack stackWords = new Stack();
            var keywords = new[] { 
            "IF" ,
            "ELSE",
            "ELSEIF",
            "THEN", 
            "ENDIF"
            };
            var app = new Microsoft.Office.Interop.Word.Application();
            var file = Environment.CurrentDirectory + @"\doc.docx";
            var document = app.Documents.Open(file);
            try
            {
                int count = document.Words.Count;
                for (int i = 1; i <= count; i++)
                {
                    // Write the word.
                    string text = document.Words[i].Text.Trim().ToUpper();
                    if (keywords.Contains(text))
                    {
                        Console.WriteLine("Word {0} = {1}", i, text);
                        if (text == "IF")
                            stackWords.Push(text);
                        else if(text=="THEN")
                            stackWords.Push(text);
                        else if (text == "ELSE")
                            stackWords.Push(text);
                        else if (text == "ELSEIF")
                            stackWords.Push(text);
                        else if (text == "ENDIF")
                            while (true)
                            {
                                var peeked = stackWords.Peek();
                                if (peeked.ToString() == "IF")
                                {
                                    stackWords.Pop();
                                    break;
                                }
                                else
                                    stackWords.Pop();
                            }
                    }
                }
                if(stackWords.Count==0)
                    Console.WriteLine("Syntax sequence is valid");
                else
                    Console.WriteLine("Syntax sequence is invalid");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                document.Close();
                app.Quit();
            }
        }
