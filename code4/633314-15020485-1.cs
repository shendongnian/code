    class Program
    {
        static void Main(string[] args)
        {
            Stack stackWords = new Stack();
            var app = new Microsoft.Office.Interop.Word.Application();
            var file = Environment.CurrentDirectory + @"\doc.docx";
            var document = app.Documents.Open(file);
            try
            {
                int count = document.Words.Count;
                for (int i = 1; i <= count; i++)
                {
                    string text = document.Words[i].Text.Trim().ToUpper();
                    Vals val;
                    if(Enum.TryParse<Vals>(text, out val))
                    {
                        Console.WriteLine("Word {0} = {1}", i, text);
                        if (stackWords.Count > 0)
                        {
                            var peeked = (Vals)stackWords.Peek();
                            if (IsValidFollower(peeked, val))
                            {
                                stackWords.Push(val);
                            }
                            else
                            {
                                throw new Exception(String.Format("Exception occured at word {0}. {1} was not expected after {2}",i, val, peeked));
                            }
                        }
                        else
                        {
                            stackWords.Push(val);
                        }
                    }
                }
                Console.WriteLine("Syntax sequence is valid");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Syntax sequence is invalid");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                document.Close();
                app.Quit();
            }
        }
        public enum Vals
        {
            IF,
            THEN,
            ENDIF,
            ELSE,
            ELSEIF
        }
        public static bool IsValidFollower(Vals val1, Vals val2)
        {
            if (val1 == Vals.IF)
                return val2 == Vals.THEN;
            if (val1 == Vals.THEN)
                return val2 == Vals.ENDIF || val2 == Vals.ELSEIF || val2 == Vals.ELSE;
            if (val1 == Vals.ENDIF)
                return val2 == Vals.IF;
            if (val1 == Vals.ELSE)
                return val2 == Vals.ENDIF;
            if (val1 == Vals.ELSEIF)
                return val2 == Vals.THEN;
            return false;
        }
