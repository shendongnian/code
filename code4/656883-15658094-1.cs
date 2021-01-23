        private static Paragraph CreatePara1()
        {
            Paragraph para1 = new Paragraph();
            Run run1 = new Run(new Text("This is Paragraph one."));
            para1.Append(run1);
            return para1;
        }
        private static Paragraph CreateBreakBefore()
        {
            Paragraph paragraph2 = new Paragraph() { RsidParagraphAddition = "00BA2F0F", RsidParagraphProperties = "00BA2F0F", RsidRunAdditionDefault = "00BA2F0F" };
            ParagraphProperties paragraphProperties1 = new ParagraphProperties();
            SectionProperties sectionProperties1 = new SectionProperties() { RsidR = "00BA2F0F" };
            PageSize pageSize1 = new PageSize() { Width = (UInt32Value)12240U, Height = (UInt32Value)15840U };
            PageMargin pageMargin1 = new PageMargin() { Top = 1440, Right = (UInt32Value)1440U, Bottom = 1440, Left = (UInt32Value)1440U, Header = (UInt32Value)720U, Footer = (UInt32Value)720U, Gutter = (UInt32Value)0U };
            Columns columns1 = new Columns() { Space = "720" };
            DocGrid docGrid1 = new DocGrid() { LinePitch = 360 };
            sectionProperties1.Append(pageSize1);
            sectionProperties1.Append(pageMargin1);
            sectionProperties1.Append(columns1);
            sectionProperties1.Append(docGrid1);
            paragraphProperties1.Append(sectionProperties1);
            paragraph2.Append(paragraphProperties1);
            return paragraph2;
        }
        private static Paragraph CreatePara2()
        {
            Paragraph para2 = new Paragraph() { RsidParagraphAddition = "00BA2F0F", RsidParagraphProperties = "00BA2F0F", RsidRunAdditionDefault = "00BA2F0F" };
            BookmarkStart bookmarkStart1 = new BookmarkStart() { Name = "_GoBack", Id = "0" };
            Run run2 = new Run();
            LastRenderedPageBreak lastRenderedPageBreak1 = new LastRenderedPageBreak();
            Text text2 = new Text();
            text2.Text = "This is the paragraph two";
            run2.Append(lastRenderedPageBreak1);
            run2.Append(text2);
            para2.Append(bookmarkStart1);
            para2.Append(run2);
            BookmarkEnd bookmarkEnd1 = new BookmarkEnd() { Id = "0" };
            return para2;
        }
        private static Paragraph CreateBreakAfter()
        {
            Paragraph paragraph4 = new Paragraph() { RsidParagraphAddition = "00BA2F0F", RsidParagraphProperties = "00BA2F0F", RsidRunAdditionDefault = "00BA2F0F" };
            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            SectionProperties sectionProperties2 = new SectionProperties() { RsidR = "00BA2F0F", RsidSect = "00BA2F0F" };
            PageSize pageSize2 = new PageSize() { Width = (UInt32Value)15840U, Height = (UInt32Value)12240U, Orient = PageOrientationValues.Landscape };
            PageMargin pageMargin2 = new PageMargin() { Top = 1440, Right = (UInt32Value)1440U, Bottom = 1440, Left = (UInt32Value)1440U, Header = (UInt32Value)720U, Footer = (UInt32Value)720U, Gutter = (UInt32Value)0U };
            Columns columns2 = new Columns() { Space = "720" };
            DocGrid docGrid2 = new DocGrid() { LinePitch = 360 };
            sectionProperties2.Append(pageSize2);
            sectionProperties2.Append(pageMargin2);
            sectionProperties2.Append(columns2);
            sectionProperties2.Append(docGrid2);
            paragraphProperties2.Append(sectionProperties2);
            paragraph4.Append(paragraphProperties2);
            return paragraph4;
        }
        private static Paragraph CreatePara3()
        {
            Paragraph para3 = new Paragraph();
            Run run3 = new Run(new Text("This is Paragraph three."));
            para3.Append(run3);
            return para3;
        }
