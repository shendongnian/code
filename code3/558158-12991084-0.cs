    public class HistoryTextBox: System.Windows.Forms.TextBox
    {
        bool ignoreChange = false;
        List<string> storage = null;
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            //init storage...
            storage = new List<string>();
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            //save change to storage...
            if (!ignoreChange)
            {
                storage.Add(this.Text);
            }
        }
        public void Undo()
        {
            if (storage.Count > 0)
            {
                this.ignoreChange = true;
                this.Text = storage[storage.Count - 1];
                storage.RemoveAt(storage.Count - 1);
                this.ignoreChange = false;
            }
        }
    }
