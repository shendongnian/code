     protected override void OnHelpRequested(object sender, HelpEventArgs e)
     {
        MessageBox.Show((Control) sender).Tag);
        e.Handled = true;
        base.OnHelpRequested(sender, e);
     }
