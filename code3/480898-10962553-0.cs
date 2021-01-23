    using Word = Microsoft.Office.Interop.Word;
    ...
        var wordApp = new Word.Application();
        var doc = wordApp.Documents.Open(FileName);
        wordApp.Visible = true;
        var events = (Word.ApplicationEvents4_Event)wordApp;
        events.Quit += delegate {
            MessageBox.Show("word closed!");
        };
