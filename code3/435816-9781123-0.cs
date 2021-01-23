    interface IMyAdapter {
        string GetDisplayText();
        // ...
    }
    class TextBoxAdapter : IMyAdapter {
        private readonly TextBox tb;
        public TextBoxAdapter(TextBox tb) {
            this.tb = tb;
        }
        public string GetDisplayText() {
            return tb.Text;
        }
        // ...
    }
    ...
    public static void CreateObject(IAdapter adapter) {
        SomeObject obj = new SomeObject();
        obj.Text = adapter.GetDisplayText();
        // ...
    }
    ...
    var textBoxAdapter = new TextBoxAdapter(new TextBox());
    CreateObject(textBoxAdapter);
