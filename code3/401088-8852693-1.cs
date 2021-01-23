            PdfReader reader = new PdfReader(workingFile);
            TextAsParagraphsExtractionStrategy S = new TextAsParagraphsExtractionStrategy();
            iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(reader, 1, S);
            for (int i = 0; i < S.strings.Count; i++) {
                Console.WriteLine("Line {0,-5}: {1}", S.baselines[i], S.strings[i]);
            }
