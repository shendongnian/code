    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using iTextSharp.text.pdf;
    namespace ClassLibrary1
    {
        public class PdfToken
        {
            private PdfToken(int type, string value)
            {
                Type = type;
                Value = value;
            }
            public static PdfToken Create(PRTokeniser tokenizer)
            {
                return new PdfToken(tokenizer.TokenType, tokenizer.StringValue);
            }
            public int Type { get; private set; }
            public string Value { get; private set; }
            public bool IsOperand
            {
                get
                {
                    return Type == PRTokeniser.TK_OTHER;
                }
            }
        }
        public class PdfOperation
        {
            public PdfOperation(PdfToken operationToken, IEnumerable<PdfToken> arguments)
            {
                Name = operationToken.Value;
                Arguments = arguments;
            }
            public string Name { get; private set; }
            public IEnumerable<PdfToken> Arguments { get; private set; }
        }
        public interface IPdfParsingStrategy
        {
            void Execute(PdfOperation op);
        }
        public class PlainTextParsingStrategy : IPdfParsingStrategy
        {
            StringBuilder text = new StringBuilder();
            public PlainTextParsingStrategy()
            {
            }
            public String GetText()
            {
                return text.ToString();
            }
            #region IPdfParsingStrategy Members
            public void Execute(PdfOperation op)
            {
                // see Adobe PDF specs for additional operations
                switch (op.Name)
                {
                    case "TJ":
                        PrintText(op);
                        break;
                    case "Tm":
                        SetMatrix(op);
                        break;
                    case "Tf":
                        SetFont(op);
                        break;
                    case "S":
                        PrintSection(op);
                        break;
                    case "G":
                    case "g":
                    case "rg":
                        SetColor(op);
                        break;
                }
            }
            #endregion
            bool newSection = false;
            private void PrintSection(PdfOperation op)
            {
                text.AppendLine("------------------------------------------------------------");
                newSection = true;
            }
            private void PrintNewline(PdfOperation op)
            {
                text.AppendLine();
            }
            private void PrintText(PdfOperation op)
            {
                if (newSection)
                {
                    newSection = false;
                    StringBuilder header = new StringBuilder();
                    PrintText(op, header);
                }
                PrintText(op, text);
            }
            private static void PrintText(PdfOperation op, StringBuilder text)
            {
                foreach (PdfToken t in op.Arguments)
                {
                    switch (t.Type)
                    {
                        case PRTokeniser.TK_STRING:
                            text.Append(t.Value);
                            break;
                        case PRTokeniser.TK_NUMBER:
                            text.Append(" ");
                            break;
                    }
                }
            }
            String lastFont = String.Empty;
            String lastFontSize = String.Empty;
            private void SetFont(PdfOperation op)
            {
                var args = op.Arguments.ToList();
                string font = args[0].Value;
                string size = args[1].Value;
                //if (font != lastFont || size != lastFontSize)
                //    text.AppendLine();
                lastFont = font;
                lastFontSize = size;
            }
            String lastX = String.Empty;
            String lastY = String.Empty;
            private void SetMatrix(PdfOperation op)
            {
                var args = op.Arguments.ToList();
                string x = args[4].Value;
                string y = args[5].Value;
                if (lastY != y)
                    text.AppendLine();
                else if (lastX != x)
                    text.Append(" ");
                lastX = x;
                lastY = y;
            }
            String lastColor = String.Empty;
            private void SetColor(PdfOperation op)
            {
                lastColor = PrintCommand(op).Replace(" ", "_");
            }
            private static string PrintCommand(PdfOperation op)
            {
                StringBuilder text = new StringBuilder();
                foreach (PdfToken t in op.Arguments)
                    text.AppendFormat("{0} ", t.Value);
                text.Append(op.Name);
                return text.ToString();
            }
        }
    }
