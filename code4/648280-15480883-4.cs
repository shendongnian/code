            Paragraph paragraph = new Paragraph();
            Inline selected = null;   //**
            richTextBox1.SelectAll();
            richTextBox1.Selection.Text = "";
            string text = System.IO.File.ReadAllText(@"..\..\MainWindow.xaml.cs");
            int iZeile = 0;
            string[] split = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            foreach (string s in split)
            {
                if (iZeile != 27)
                {
                    paragraph.Inlines.Add(s + "\r\n"); // adds line added without marking
                }
                else
                {
                    Run run = new Run(split[27]); // adds line with marking
                    run.Background = Brushes.Yellow;
                    paragraph.Inlines.Add(run);
                    paragraph.Inlines.Add("\r\n");
                    selected = run;                // ** remember this element
                }
                iZeile++;
            }
            FlowDocument document = new FlowDocument(paragraph);
            richTextBox1.Document = new FlowDocument();
            richTextBox1.Document = document;
            Keyboard.Focus(richTextBox1);
            DoEvents();                   // ** this is required, probably a bug
            selected.BringIntoView();     // ** 
