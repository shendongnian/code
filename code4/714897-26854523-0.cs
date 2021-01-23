    // "document" is a Microsoft.Office.Tools.Word.Document
    var selected = document.Application.Selection.Range;
    if(Math.Abs(selected.End - selected.Start) == 0)
    {
        var count = document.Application.ActiveDocument.SpellingErrors.Count;
    }
