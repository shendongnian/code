    if (!projectItem.IsOpen)
        projectItem.Open(@"{7651A701-06E5-11D1-8EBD-00A0C90F26EA}").Document.Activate(); //EnvDTE.Constants.vsViewKindCode
    
    TextSelection selection = _vsApp.ActiveDocument.Selection;
    selection.SelectAll();
    string text = selection.Text;
    selection.Delete();
    //Do replacements
    text = ReplaceTemplateValues(text, replacements);
    selection.Insert(text);
