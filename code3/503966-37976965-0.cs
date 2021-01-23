    private static Stylesheet CreateStylesheet()
        {
            Stylesheet ss = new Stylesheet();
            Fonts fonts = new Fonts(new OpenXmlElement[]
            {
                new Font
                {
                    FontName = new FontName { Val = "Calibri" },
                    FontSize = new FontSize { Val = 11 }
                }
            });
            fonts.Count = (uint)fonts.ChildElements.Count;
            Fills fills = new Fills(new OpenXmlElement[]
            {
                new Fill
                {
                    PatternFill = new PatternFill { PatternType = PatternValues.None }
                }
            });
            fills.Count = (uint)fills.ChildElements.Count;
            Borders borders = new Borders(new OpenXmlElement[]
            {
                new Border
                {
                    LeftBorder = new LeftBorder(),
                    RightBorder = new RightBorder(),
                    TopBorder = new TopBorder(),
                    BottomBorder = new BottomBorder(),
                    DiagonalBorder = new DiagonalBorder(),
                }
            });
            borders.Count = (uint)borders.ChildElements.Count;
            CellStyleFormats csfs = new CellStyleFormats(new OpenXmlElement[] 
            {
                new CellFormat
                {
                    NumberFormatId = 0,
                    FontId = 0,
                    FillId = 0,
                    BorderId = 0,
                }
            });
            csfs.Count = (uint)csfs.ChildElements.Count;
            CellFormats cfs = new CellFormats(new OpenXmlElement[]
            {
                new CellFormat
                {
                    NumberFormatId = 0,
                    FontId = 0,
                    FillId = 0,
                    BorderId = 0,
                    FormatId = 0,
                },
                new CellFormat
                {
                    NumberFormatId = 14,
                    FontId = 0,
                    FillId = 0,
                    BorderId = 0,
                    FormatId = 0,
                    ApplyNumberFormat = true
                }
            });
            cfs.Count = (uint)cfs.ChildElements.Count;
            
            ss.Append(fonts);
            ss.Append(fills);
            ss.Append(borders);
            ss.Append(csfs);
            ss.Append(cfs);
            DifferentialFormats dfs = new DifferentialFormats();
            dfs.Count = 0;
            ss.Append(dfs);
            TableStyles tss = new TableStyles();
            tss.Count = 0;
            tss.DefaultTableStyle = "TableStyleMedium9";
            tss.DefaultPivotStyle = "PivotStyleLight16";
            ss.Append(tss);
            return ss;
        }
