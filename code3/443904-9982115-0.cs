        public void StartConvert(String originalFile, String newFile)
        {
            GC.Collect();
            Document myDocument = new Document(PageSize.LETTER);
            PdfWriter.GetInstance(myDocument, new FileStream(newFile, FileMode.Create));
            myDocument.Open();
            int totalfonts = FontFactory.RegisterDirectory("C:\\WINDOWS\\Fonts");
            iTextSharp.text.Font content = FontFactory.GetFont("Pea Heather's Handwriting", 13);//13
            iTextSharp.text.Font header = FontFactory.GetFont("assign", 16); //16
            //string fontpath = Server.MapPath(".");
            BaseFont customfont = BaseFont.CreateFont(@"font1.ttf", BaseFont.CP1252, BaseFont.EMBEDDED);
            Font font = new Font(customfont, 13);
            string s = " ";
            myDocument.Add(new Paragraph(s, font));
            BaseFont customfont2 = BaseFont.CreateFont(@"font2.ttf", BaseFont.CP1252, BaseFont.EMBEDDED);
            Font font2 = new Font(customfont2, 16);
            string s2 = " ";
            myDocument.Add(new Paragraph(s2, font2));
            try
            {
                GC.Collect();
                try
                {
                    GC.Collect();
                   
                    using (StreamReader sr = new StreamReader(originalFile))
                    {
                        GC.Collect();
                        // Read and display lines from the file until the end of
                        // the file is reached.
                        String line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            GC.Collect();
                            String newTempLine = "";
                            String[] textArray;
                            textArray = line.Split(' ');
                            newTempLine = returnSpaces(RandomNumber(0, 6)) + newTempLine;
                            int counterMax = RandomNumber(8, 12);
                            int counter = 0;
                            foreach (String S in textArray)
                            {
                                if (counter == counterMax)
                                {
                                    Paragraph P = new Paragraph(newTempLine + Environment.NewLine, font);
                                    P.Alignment = Element.ALIGN_LEFT;
                                    myDocument.Add(P);
                                    newTempLine = "";
                                    newTempLine = returnSpaces(RandomNumber(0, 6)) + newTempLine;
                                    GC.Collect();
                                }
                                newTempLine = newTempLine + returnSpaces(RandomNumber(1, 5)) + S;
                                counter++;
                                GC.Collect();
                            }
                            Paragraph T = new Paragraph(newTempLine, font2);
                            T.Alignment = Element.ALIGN_LEFT;
                            myDocument.Add(T);
                            GC.Collect();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                    GC.Collect();
                }
                GC.Collect();
            }
            catch (DocumentException de)
            {
                Console.Error.WriteLine(de.Message);
            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine(ioe.Message);
            }
            try
            {
                myDocument.Close();
            }
            catch { }
        }
