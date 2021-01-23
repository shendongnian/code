    protected override void OnCreateControl()
    {
       base.OnCreateControl();
       if (DesignMode)
            this.Text = Microsoft.VisualBasic.Interaction.InputBox("Enter text: ");
    }
