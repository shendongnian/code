    /// <summary>
        /// Changes a font from originalFont appending other properties
        /// </summary>
        /// <param name="originalFont">Original font of text
        /// <param name="familyName">Target family name
        /// <param name="emSize">Target text Size
        /// <param name="fontStyle">Target font style
        /// <param name="enableFontStyle">true when enable false when disable
        /// <returns>A new font with all provided properties added/removed to original font</returns>
        private Font RenderFont(Font originalFont, string familyName, float? emSize, FontStyle? fontStyle, bool? enableFontStyle)
        {
            if (fontStyle.HasValue && fontStyle != FontStyle.Regular && fontStyle != FontStyle.Bold && fontStyle != FontStyle.Italic && fontStyle != FontStyle.Underline)
                throw new System.InvalidProgramException("Invalid style parameter to ChangeFontStyleForSelectedText");
 
            Font newFont;
            FontStyle? newStyle = null;
            if (fontStyle.HasValue)
            {
                if (fontStyle.HasValue && fontStyle == FontStyle.Regular)
                    newStyle = fontStyle.Value;
                else if (originalFont != null && enableFontStyle.HasValue && enableFontStyle.Value)
                    newStyle = originalFont.Style | fontStyle.Value;
                else
                    newStyle = originalFont.Style & ~fontStyle.Value;
            }
 
            newFont = new Font(!string.IsNullOrEmpty(familyName) ? familyName : originalFont.FontFamily.Name,
                                emSize.HasValue ? emSize.Value : originalFont.Size,
                                newStyle.HasValue ? newStyle.Value : originalFont.Style);
            return newFont;
        }
