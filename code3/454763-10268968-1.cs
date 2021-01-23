    for (var i = 0; i < this.Controls.Count; i++)
    {
        var tp = this.Controls[i] as TransparentPicture;
        if (tp != null)
        {
            tp.IsTransparent = true;
        }
    }
