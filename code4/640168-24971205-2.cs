                if (c.HasRichText || textRotation != 0 || c.InnerText.Contains(Environment.NewLine))
                {
                   // omissis...
                }
                else
                    thisHeight = c.Style.Font.GetHeight( fontCache);
