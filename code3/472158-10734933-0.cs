            mailMerge = doc.MailMerge;         
            foreach (Word.MailMergeField f in mailMerge.Fields)         
            {    
                 // Extract the name of the MergeField starting from the 11 character
                 // and looking for the first space after the name 
                 // (this means that you avoid MergeFields names with embedded spaces)
                 string fieldName = f.Code.Text.Substring(11).Trim();
                 int  pos = fieldName.IndexOf(' ');
                 if (pos >= 0) fieldName = fieldName.Substring(0, pos).Trim();
                 if (fieldName == pMergeField) 
                 {
                       f.Select();                  
                       app.Selection.TypeText(pValue);  
                 }
