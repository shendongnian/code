    public static class RichTextBoxExtensions
    {
        /// <summary>
        /// Gets the content of the <see cref="RichTextBox"/> as the actual RTF.
        /// </summary>
        public static string GetAsRTF(this RichTextBox richTextBox)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                textRange.Save(memoryStream, DataFormats.Rtf);
                memoryStream.Seek(0, SeekOrigin.Begin);
                using (StreamReader streamReader = new StreamReader(memoryStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
        /// <summary>
        /// Gets the content of the <see cref="RichTextBox"/> as plain text only.
        /// </summary>
        public static string GetAsText(this RichTextBox richTextBox)
        {
            return new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
        }
        /// <summary>
        /// Gets the number of lines in the <see cref="RichTextBox"/>.
        /// </summary>
        public static int GetLineCount(this RichTextBox richTextBox)
        {
            // Idea: Every paragraph in a RichTextBox ends with a \par.
            // Special handling for empty RichTextBoxes, because while there is
            // a \par, there is no line in the strict sense yet.
            if (String.IsNullOrWhiteSpace(richTextBox.GetAsText()))
            {
                return 0;
            }
            // Simply count the occurrences of \par to get the number of lines.
            // Subtract 1 from the actual count because the first \par is not
            // actually a line for reasons explained above.
            return Regex.Matches(richTextBox.GetAsRTF(), Regex.Escape(@"\par")).Count - 1;
        }
    }
