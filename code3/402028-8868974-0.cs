    void SearchTextBox(Word.Document oDoc,string name,string newContent)
        {
            foreach (Word.Shape shape in oDoc.Shapes)
                if (shape.Name == name)
                {
                    shape.TextFrame.ContainingRange.Text = newContent;
                    return;
                }
        }
