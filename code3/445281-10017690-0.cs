    public class MessageBox : IMessageBox {
        private readonly InstanceGenerator generator;
        public MessageBox(InstanceGenerator generator) {
            this.generator = generator;
        }
        public static void Show(string Text) {
            generator.MessageBoxImpl.Show(Text);
        }
    
        public static void Show(string text, string description, MessageBoxType type) {
            generator.MessageBoxImpl.Show(text, description, type);
        }
        public static MessageBoxResult ShowYesNo(string text, string description, 
                                                 MessageBoxType type) {
            return generator.MessageBoxImpl.ShowYesNo(text, description, type);
        }
        public static MessageBoxResult ShowYesNoCancel(string text, string description, 
            MessageBoxType type) {
            return generator.MessageBoxImpl.ShowYesNoCancel(text, description, type);
        }
    }
