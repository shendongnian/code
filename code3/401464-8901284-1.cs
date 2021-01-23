    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using iTextSharp.text.pdf;
    namespace ClassLibrary1
    {
        public class PdfExtractor
        {
            public static string GetText(byte[] pdfBuffer)
            {
                PlainTextParsingStrategy strategy = new PlainTextParsingStrategy();
                ParsePdf(pdfBuffer, strategy);
                return strategy.GetText();
            }
            private static void ParsePdf(byte[] pdf, IPdfParsingStrategy strategy)
            {
                PdfReader reader = new PdfReader(pdf);
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    byte[] page = reader.GetPageContent(i);
                    if (page != null)
                    {
                        PRTokeniser tokenizer = new PRTokeniser(page);
                        List<PdfToken> parameters = new List<PdfToken>();
                        while (tokenizer.NextToken())
                        {
                            var token = PdfToken.Create(tokenizer);
                            if (token.IsOperand)
                            {
                                strategy.Execute(new PdfOperation(token, parameters));
                                parameters.Clear();
                            }
                            else
                            {
                                parameters.Add(token);
                            }
                        }
                    }
                }
            }
        }
    }
