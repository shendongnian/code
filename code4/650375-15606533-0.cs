    Document oldDoc = itemToReplyTo.GetInspector.WordEditor;
    Document newDoc = newMailItem.GetInspector.WordEditor;
    if (oldDoc != null)
    {
        Microsoft.Office.Interop.Word.Selection oldSelect = oldDoc.Windows[1].Selection;
        Microsoft.Office.Interop.Word.Selection newSelect = newDoc.Windows[1].Selection;
        oldSelect.Find.Execute("From:");
        oldSelect.Collapse(WdCollapseDirection.wdCollapseStart);
        oldSelect.MoveEnd(WdUnits.wdStory, 1);
        oldSelect.Copy();
        newSelect.Move(WdUnits.wdStory, 1);
        newSelect.InlineShapes.AddHorizontalLineStandard();
        newSelect.Paste();
        newSelect.Move(WdUnits.wdStory, -1);
        newSelect.InsertAfter("Reply Text here");
        newSelect.Find.ClearFormatting();
        newSelect.Find.Execute(mailItem.SenderEmailAddress);
    }
