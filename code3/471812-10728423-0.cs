    var allControls =  tabControl1.TabPages
                       .Cast<TabPage>()
                       .Select(tp => tp.Controls);
    var allTextBoxes     =  allControls.OfType<TextBox>();
    var allRichTextBoxes =  allControls.OfType<RichTextBox>();
    var allTextControls  =  allTextBoxes
                            .Cast<TextBoxBase>()
                            .Concat(allRichTextBoxes.Cast<TextBoxBase>());
    foreach(var textControl in allTextControls)
    {
        textControl.Text = "";
    }
