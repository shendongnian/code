    CreateControls(TabPage tabPage)
    {
    var code = new TextBox();
    CodesMy.Add(code);
    code.Location = new Point(12, _nextTextBoxTop);
    _nextTextBoxTop += 36;
    code.Size = new Size(80, 25);
    code.Text = mcode;
    tabPage.Controls.Add.Controls.Add(code);     
    }
