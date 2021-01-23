    namespace AvalonEditIntegration.UI
    {
        using System.Windows;
        using System.Windows.Input;
        using ICSharpCode.AvalonEdit.Document;
    
        public class ViewModel
        {
            public ViewModel()
            {
                ShowCode = new DelegatingCommand(Show);
                Document = new TextDocument();
            }
    
            public ICommand ShowCode { get; private set; }
            public TextDocument Document { get; set; }
    
            private void Show()
            {
                MessageBox.Show(Document.Text);
            }
        }
    }
