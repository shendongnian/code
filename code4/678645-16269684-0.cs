    Control[] matches;
    for (int i = 0; i < 35; i++)
    {
        br.BaseStream.Position = 0x6316 + i * 4;
        matches = this.Controls.Find("numericUpDown" + (91 - i).ToString(), true);
        if (matches.Length > 0 && matches[0] is NumericUpDown)
        {
            ((NumericUpDown)matches[0]).Value = br.ReadInt16();
        }
    }
