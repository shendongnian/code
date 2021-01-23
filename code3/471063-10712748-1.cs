    item.Text = "This is a test of an extended line of text.";
    class PresetListBoxItem
    {
        public uint[] preset;
        public string Text { get; set; }
        public PresetListBoxItem(uint[] preset = null, string content = "N/A")
          : base()
        {
            this.preset = preset;
            this.Text = content;
        }
    }
