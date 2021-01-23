     Section section = this.Document.Sections.First;
     foreach (HeaderFooter header in section.Headers)
     {
       if (header.Exists) 
       {
         header.Range.Words.First.Select()
         break;
       }
     }
