    using PropertyGridExtensionHacks;
    //...
        private void buttonMoveSplitter_Click(object sender, EventArgs e)
        {
            int splitterPosition = this.propertyGrid1.GetInternalLabelWidth();
            this.propertyGrid1.MoveSplitterTo(splitterPosition + 10);
        }
