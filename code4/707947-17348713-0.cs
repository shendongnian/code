       public FormattedText AddFormattedText(string text, string style)
        {
          FormattedText formattedText = AddFormattedText(text);
          formattedText.Style = style;
          return formattedText;
        }
  
     internal class FormattedTextRenderer : RendererBase
       ...
     /// <summary>
        /// Renders the style if it is a character style and the font of the formatted text.
        /// </summary>
        void RenderStyleAndFont()
        {
          bool hasCharacterStyle = false;
          if (!this.formattedText.IsNull("Style"))
          {
            Style style = this.formattedText.Document.Styles[this.formattedText.Style];
            if (style != null && style.Type == StyleType.Character)
              hasCharacterStyle = true;
          }
          object font = GetValueAsIntended("Font");
          if (font != null)
          {
            if (hasCharacterStyle)
              this.rtfWriter.WriteControlWithStar("cs", this.docRenderer.GetStyleIndex(this.formattedText.Style));
    
            RendererFactory.CreateRenderer(this.formattedText.Font, this.docRenderer).Render();
          }
        }
