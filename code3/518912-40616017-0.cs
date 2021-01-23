    // Use for asynchronous highlight
    public delegate void VoidActionOnRichTextBox(RichTextBox richTextBox);
    // Extension Class
    public static class RichTextBoxExtensions
    {
        public static void HighlightXml(this RichTextBox richTextBox)
        {
            new StandardHighlight().HighlightXml(richTextBox);
        }
        public async static void HighlightXmlAsync(this RichTextBox richTextBox)
        {
            var helper = new StandardHighlight();
            var win = new MainWindow();
            await Task.Factory.StartNew(() =>
            {
                richTextBox.Dispatcher.BeginInvoke(new VoidActionOnRichTextBox(helper.HighlightXml), richTextBox);
            });
        }        
    }
    // You can extent it with more highlight methods
    public class StandardHighlight
    {        
        public void HighlightXml(RichTextBox richTextBox)
        {
            // Collect Text-Box Information
            var textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
            XDocument xDocument;
            try
            {
                xDocument = XDocument.Parse(textRange);
            }
            catch
            {
                return;
            }
            var documentLines = xDocument.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            // Get the Longest Line Length
            int? maxVal = null;
            for (int i = 0; i < documentLines.Length; i++)
            {
                int thisNum = documentLines[i].Length;
                if (!maxVal.HasValue || thisNum > maxVal.Value) { maxVal = thisNum; }
            }
            // Set Text-Box Width & Clear the Current Content
            if (maxVal != null) richTextBox.Document.PageWidth = (double)maxVal * 5.5;
            richTextBox.Document.Blocks.Clear();
            #region *** Process Lines ***
            foreach (var documentLine in documentLines)
            {
                // Parse XML Node Components
                var indentSpace = Regex.Match(documentLine, @"\s+").Value;
                var xmlTags = Regex.Matches(documentLine, @"(<[^/].+?)(?=[\s])|(<[^/].+?>)|(</.+?>)");
                if (documentLine.Contains("<!--")) xmlTags = Regex.Matches(documentLine, @"(<[^/].+?>)"); // Parse comments
                var nodeAttributes = Regex.Matches(documentLine, @"(?<=\s)(.+?)(?=\s)");
                // Process XML Node
                var nodeAttributesCollection = new List<Run>();
                if (nodeAttributes.Count > 0)
                {
                    for (int i = 0; i < nodeAttributes.Count; i++)
                    {
                        if (!(nodeAttributes[i].Value.Length < 2) && !(documentLine.Contains("<!--")))
                        {
                            var attributeName = $"{Regex.Match(nodeAttributes[i].Value, @"(.+?=)").Value}";
                            if (i == 0) attributeName = $" {Regex.Match(nodeAttributes[i].Value, @"(.+?=)").Value}";
                            var attributeValue = $"{Regex.Match(nodeAttributes[i].Value, @"(?<=(.+?=))"".+?""").Value} ";
                            if (i == nodeAttributes.Count - 1) attributeValue = attributeValue.Trim();
                            nodeAttributesCollection.Add(new Run { Foreground = new SolidColorBrush(Colors.Green), Text = $"{attributeName}" });
                            nodeAttributesCollection.Add(new Run { Foreground = new SolidColorBrush(Colors.Brown), Text = $"{attributeValue}" });
                        }
                    }
                }
                // Initialize IndentSpace
                Run run = null;
                if (indentSpace.Length > 1) run = new Run { Text = indentSpace };
                // Initialize Open Tag
                var tagText = xmlTags[0].Value.Substring(1, xmlTags[0].Value.Length - 2);
                var tagTextBrush = new SolidColorBrush(Colors.Blue);
                var tagBorderBruh = new SolidColorBrush(Colors.Red);
                if (tagText.StartsWith("!--"))
                {
                    tagTextBrush = new SolidColorBrush(Colors.DarkSlateGray);
                    tagBorderBruh = new SolidColorBrush(Colors.DarkSlateGray);
                }
                var openTag = new Run
                {
                    Foreground = tagTextBrush,
                    Text = tagText
                };
                // Initialize Content Tag
                var content = new Run
                {
                    Foreground = new SolidColorBrush(Colors.Black),
                };
                // Initialize Paragraph
                var paragraph = new Paragraph();
                paragraph.Margin = new Thickness(0);
                if (run != null) paragraph.Inlines.Add(run); // Add indent space if exist
                // Process Open Tag
                paragraph.Inlines.Add(new Run { Foreground = tagBorderBruh, Text = "<" });
                paragraph.Inlines.Add(openTag);
                // Process Open Tag Attributes
                if (nodeAttributesCollection.Count > 0)
                {
                    nodeAttributesCollection.ForEach(attribute => { paragraph.Inlines.Add(attribute); });
                    nodeAttributesCollection.Clear();
                }
                paragraph.Inlines.Add(new Run { Foreground = tagBorderBruh, Text = ">" });
                // Process Closing Tag
                if (xmlTags.Count > 1)
                {
                    Run closingTag = new Run();
                    content.Text = documentLine.Replace(xmlTags[0].Value, "").Replace(xmlTags[1].Value, "").Trim();
                    closingTag = new Run
                    {
                        Foreground = new SolidColorBrush(Colors.Blue),
                        Text = xmlTags[1].Value.Substring(1, xmlTags[1].Value.Length - 2)
                    };
                    paragraph.Inlines.Add(content);
                    paragraph.Inlines.Add(new Run { Foreground = new SolidColorBrush(Colors.Red), Text = "<" });
                    paragraph.Inlines.Add(closingTag);
                    paragraph.Inlines.Add(new Run { Foreground = new SolidColorBrush(Colors.Red), Text = ">" });
                }
                richTextBox.Document.Blocks.Add(paragraph);
            }
            #endregion
        }
    }
