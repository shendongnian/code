    public static void GetAndSetStyleFromDoc(string file)
    {
                bool styleExists = true;
    
                using (var document = WordprocessingDocument.Open(file,true))
                {
    
                    // Get the Styles part for this document
                    StyleDefinitionsPart part = document.MainDocumentPart.StyleDefinitionsPart;
    
                    foreach (Style style in part.RootElement.Elements<Style>())
                    {
                        // PartA can be changed for "Normal", "Header1" etc
                        if (style.StyleId.Value.Equals("PartA", StringComparison.InvariantCultureIgnoreCase))
                        {
                            style.StyleParagraphProperties.SpacingBetweenLines.Line = "276";
                            style.StyleRunProperties.FontSize.Val = "14";
                            style.StyleRunProperties.Color.Val = "4F81BD"; // font color
                            
                            ParagraphBorders paragraphBorders1 = new ParagraphBorders();
                            TopBorder topBorder1 = new TopBorder(){ Val = BorderValues.Single, Color = "856363", Size = (UInt32Value)24U, Space = (UInt32Value)0U };
                            LeftBorder leftBorder1 = new LeftBorder(){ Val = BorderValues.Single, Color = "856363", Size = (UInt32Value)24U, Space = (UInt32Value)0U };
                            BottomBorder bottomBorder1 = new BottomBorder(){ Val = BorderValues.Single, Color = "856363", Size = (UInt32Value)24U, Space = (UInt32Value)0U };
                            RightBorder rightBorder1 = new RightBorder(){ Val = BorderValues.Single, Color = "856363", Size = (UInt32Value)24U, Space = (UInt32Value)0U };
    
                            paragraphBorders1.Append(topBorder1);
                            paragraphBorders1.Append(leftBorder1);
                            paragraphBorders1.Append(bottomBorder1);
                            paragraphBorders1.Append(rightBorder1);
    
                            style.StyleParagraphProperties.ParagraphBorders = paragraphBorders1;
                        }
                    }
    
                }
    }
