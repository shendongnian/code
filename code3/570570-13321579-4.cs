    ...
    // The paragraph before the current list is also a list -> so in order to insert text, we must do "some magic"
    else if(prevRange.ListParagraphs.Count > 0)
    {
        // First, insert a new line -> this causes a new item to be inserted into the above list
        prevRange.InsertAfter("\r");
                        
        // Modify current range to be on the line of the new list item
        prevRange.Start = prevRange.Start + 1;
        prevRange.End = prevRange.Start;
    
        // Convert the list item line into a paragraph by removing its numbers
        prevRange.ListFormat.RemoveNumbers();
    
        // Insert the text
        prevRange.InsertBefore(myText);
    }
    ...
