    using System.Drawing.Text;
    ...
    InstalledFontCollection inst = new InstalledFontCollection();
    foreach (FontFamily fnt in inst.Families)
    {
        comboBox.Items.Add(fnt.Name);
    }
