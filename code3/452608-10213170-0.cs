    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        if (!Regex.Match(new StringBuilder(Text).Append(e.KeyChar).ToString(), MaskPattern))
        {
            e.Handled = true;
        }
        else
            base.OnKeyPress(e);
    }
