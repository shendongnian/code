    public new event EventHandler Click {
    add {
    base.Click += value;
    base.PreviewKeyDown += new PreviewKeyDownEventHandler(value);
    foreach (Control i in Controls) {
    i.Click += value;
    i.PreviewKeyDown += new PreviewKeyDownEventHandler(value);
    }
    }
    remove {
    //same code with -= instead of +=, but the previewkeydown event is excluded because i couldnt find a way to remove it.
    }
    }
