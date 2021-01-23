        public string GetWordByCaret(LogicalDirection direction)
        {
            // Get the CaretPosition
            TextPointer position = this.CaretPosition;
            TextPointerContext context = position.GetPointerContext(direction);
            string text = string.Empty;
            // Iterate through the RichTextBox based on the Start, Text and End of nearby inlines
            while (context != TextPointerContext.None)
            {
                // We are only interested in the text here
                //, so ignore everything that is not text
                if (context == TextPointerContext.Text)
                {
                    string current = position.GetTextInRun(direction);
                    // The strings appended based on whether they are before the caret or after it...
                    // And well...I love switches :)
                    switch (direction)
                    {
                        case LogicalDirection.Backward:
                            {
                                int spaceIndex = current.LastIndexOf(' ');
                                
                                // If space is found, we've reached the end
                                if (spaceIndex >= 0)
                                {
                                    int length = current.Length - 1;
                                    if (spaceIndex + 1 <= length)
                                    {
                                        text = current.Substring(spaceIndex + 1, length - spaceIndex) + text;
                                    }
                                    return text;
                                }
                                else
                                    text = current + text;
                            }
                            break;
                        default:
                            {
                                int spaceIndex = current.IndexOf(' ');
                                // If space is found, we've reached the end
                                if (spaceIndex >= 0)
                                {
                                    int length = current.Length;
                                    if (spaceIndex <= length)
                                    {
                                        text += current.Substring(0, spaceIndex);
                                    }
                                    return text;
                                }
                                else
                                    text += current;
                            }
                            break;
                    }
                }
                // Move to the next position
                position = position.GetNextContextPosition(direction);
                // Get the next context
                if (position != null)
                    context = position.GetPointerContext(direction);
                else
                    context = TextPointerContext.None;
            }
            return text;
        }
