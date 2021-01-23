    public class Fluent
    {
        public ControlPanelCreator CreateControlPanel()
        {
            return new ControlPanelCreator(new StackPanel(), this);
        }
    }
    public class ControlPanelCreator
    {
        #region Fields
        private Fluent fluent;
        private Panel panel;
        #endregion
        #region Constructors
        internal ControlPanelCreator(Panel panel, Fluent fluent)
        {
            this.fluent = fluent;
            this.panel = panel;
        }
        #endregion
        #region Methods
        public ControlPanelChildrenCreator Children()
        {
            return new ControlPanelChildrenCreator(this.panel, this);
        }
        #endregion
    }
    public class ControlPanelChildrenCreator
    {
        #region Fields
        private ControlPanelCreator panelCreator;
        private Panel panel;
        #endregion
        #region Constructors
        internal ControlPanelChildrenCreator(Panel panel, ControlPanelCreator panelCreator)
        {
            this.panel = panel;
            this.panelCreator = panelCreator;
        }
        #endregion
        #region Methods
        public ListBoxCreator AddListBox()
        {
            ListBox listBox = new ListBox();
            this.panel.Children.Add(listBox);
            return new ListBoxCreator(listBox, this);
        }
        public TextBoxCreator AddTextBox()
        {
            TextBox textBox = new TextBox();
            this.panel.Children.Add(textBox);
            return new TextBoxCreator(textBox, this);
        }
        public Panel GetControlPanel()
        {
            return this.panel;
        }
        #endregion
    }
    public class ListBoxCreator
    {
        #region Fields
        private ListBox listbox;
        private ControlPanelChildrenCreator parentCreator;
        #endregion
        #region Constructors
        internal ListBoxCreator(ListBox listBox, ControlPanelChildrenCreator parentCreator)
        {
            this.listbox = listBox;
            this.parentCreator = parentCreator;
        }
        #endregion
        #region Methods
        public ListBoxCreator SetWidth(int width)
        {
            this.listbox.Width = width;
            return this;
        }
        public ListBoxCreator AddMouseEnterEvent(Action<object, MouseEventArgs> action)
        {
            this.listbox.MouseEnter += new MouseEventHandler(action);
            return this;
        }
        public ControlPanelChildrenCreator Create()
        {
            return this.parentCreator;
        }
        #endregion
    }
    public class TextBoxCreator
    {
        #region Fields
        private TextBox textBox;
        private ControlPanelChildrenCreator parentCreator;
        #endregion
        #region Constructors
        internal TextBoxCreator(TextBox textBox, ControlPanelChildrenCreator parentCreator)
        {
            this.textBox = textBox;
            this.parentCreator = parentCreator;
        }
        #endregion
        #region Methods
        public TextBoxCreator SetText(string defaultText)
        {
            this.textBox.Text = defaultText;
            return this;
        }
        public ControlPanelChildrenCreator Create()
        {
            return this.parentCreator;
        }
        #endregion
    }
