    namespace CodeUnderTest
    {
        public interface IMessageBox
        {
            DialogResult Show(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon);
        }
    
        public class MessageBoxService : IMessageBox
        {
            public DialogResult Show(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
            {
                return MessageBox.Show(message, title, buttons, icon);
            }
        }
    
        public class MessageBoxFake : IMessageBox
        {
            public DialogResult Show(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
            {
                return DialogResult.OK;
            }
        }
    
    
        public class Repository
        {
            private readonly TextWriter _console;
            private readonly IMessageBox _messageBox;
    
            public Repository(TextWriter console, IMessageBox msgBox)
            {
                _console = console;
                _messageBox = msgBox;
            }
    
            public void WriteTop20Tags(Dictionary<string, int> list)
            {
                selectTop20Tags(list, _console, _messageBox);
            }
    
            private static void selectTop20Tags(Dictionary<string, int> list, TextWriter _console, IMessageBox _messageBox)
            {
                try
                {
                    //Outputs the top 20 most common hashtags in descending order
                    foreach (KeyValuePair<string, int> pair in list.OrderByDescending(key => key.Value).Take(20))
                    {
                        _console.WriteLine("{0}, {1}", pair.Key, pair.Value);
                    }
                }
                catch (NullReferenceException e)
                {
                    _messageBox.Show(e.Message, "Error detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
