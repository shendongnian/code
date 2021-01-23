    using Microsoft.Office.Interop.Word;
    // Create a word app
    Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
    // Change setting so that hyperlinks do not update on save
    DefaultWebOptions WordOptions = winword.DefaultWebOptions();
    WordOptions.UpdateLinksOnSave = false; // or true in your case
