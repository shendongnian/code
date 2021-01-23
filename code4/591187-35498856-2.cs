    // Loop through all lines in the document.
    Application application = new Application();
    Document document = application.Documents.Open("C:\\new folder\\word.docx");
                       String read = string.Empty;
            List<string> data = new List<string>();
            for (int i = 0; i < document.Paragraphs.Count; i++)
            {
                string temp = document.Paragraphs[i + 1].Range.Text.Trim();
                if (temp != string.Empty)
                    data.Add(temp);
            }
            // Close word.
            application.Quit();`
