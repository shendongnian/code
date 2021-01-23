    public class ViewModel 
    {
        string fileName = @"D:\testRichTextBox1Text.txt";
        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new DelegateCommand(SaveToTextFile);
                }
                return saveCommand;
            }
        }
        public void SaveToTextFile(object document)
        {
            TextRange range;
            FileStream fileStream;
            range = new TextRange(((FlowDocument)document).ContentStart,
                                  ((FlowDocument)document).ContentEnd);
            fileStream = new FileStream(fileName, FileMode.Create);
            range.Save(fileStream, DataFormats.Text);
            fileStream.Close();
            MessageBox.Show("Text File Saved");
        }
    }
