    private void butGenerate_Click(object sender, EventArgs e)
    {
       SaveWordTemp2WordDoc();      
    }
    public void SaveWordTemp2WordDoc()
    {
        //OBJECT OF MISSING "NULL VALUE"
        object oMissing = System.Reflection.Missing.Value;
        //OBJECTS OF FALSE AND TRUE
        Object oTrue = true;
        Object oFalse = false;
        //CREATING OBJECTS OF WORD AND DOCUMENT
        Word.Application oWord = new Word.Application();
        Word.Document oWordDoc = new Word.Document();
        //SETTING THE VISIBILITY TO TRUE
        //oWord.Visible = true;
        //THE LOCATION OF THE TEMPLATE FILE ON THE MACHINE
        //Change the path to a path like c:\files\docTemps\
        Object oTemplatePath = @"C:\Documents and Settings\YYC\Desktop\TestTemplate.dotx";
        //ADDING A NEW DOCUMENT FROM A TEMPLATE
        oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);
        int iTotalFields = 0;
        foreach (Word.Field myMergeField in oWordDoc.Fields)
        {
            iTotalFields++;
            Word.Range rngFieldCode = myMergeField.Code;
            String fieldText = rngFieldCode.Text;
            // ONLY GETTING THE MAILMERGE FIELDS
            if (fieldText.StartsWith(" MERGEFIELD"))
            {
                // THE TEXT COMES IN THE FORMAT OF
                // MERGEFIELD  MyFieldName  \\* MERGEFORMAT
                // THIS HAS TO BE EDITED TO GET ONLY THE FIELDNAME "MyFieldName"
                Int32 endMerge = fieldText.IndexOf("\\");
                Int32 fieldNameLength = fieldText.Length - endMerge;
                String fieldName = fieldText.Substring(11, endMerge - 11);
                // GIVES THE FIELDNAMES AS THE USER HAD ENTERED IN .dot FILE
                fieldName = fieldName.Trim();
                // **** FIELD REPLACEMENT IMPLEMENTATION GOES HERE ****//
                // THE PROGRAMMER CAN HAVE HIS OWN IMPLEMENTATIONS HERE
                if (fieldName == "Name")
                {
                    myMergeField.Select();
                    //Check whether the control text is empty
                    if (txtName.Text == "")
                    {
                        oWord.Selection.TypeText(" ");
                    }
                    else
                    {
                        oWord.Selection.TypeText(txtName.Text);
                    }
                }
                if (fieldName == "Address")
                {
                    myMergeField.Select();
                    //Check whether the control text is empty
                    if (txtAddress.Text == "")
                    {
                        oWord.Selection.TypeText(" ");
                    }
                    else
                    {
                        oWord.Selection.TypeText(txtAddress.Text);
                    }
                }
                if (fieldName == "Age")
                {
                    myMergeField.Select();
                    // check whether the control text is empty
                    if (txtAge.Text == "")
                    {
                        oWord.Selection.TypeText(" ");
                    }
                    else
                    {
                        oWord.Selection.TypeText(txtAge.Text);
                    }
                }
                if (fieldName == "EAddress")
                {
                    myMergeField.Select();
                    // check whether the control text is empty
                    if (txtEmail.Text == "")
                    {
                        oWord.Selection.TypeText(" ");
                    }
                    else
                    {
                        oWord.Selection.TypeText(txtEmail.Text);
                    }
                }
                if (fieldName == "Company")
                {
                    myMergeField.Select();
                    // Check whether the control text is empty
                    if (txtCompany.Text == "")
                    {
                        oWord.Selection.TypeText(" ");
                    }
                    else
                    {
                        oWord.Selection.TypeText(txtCompany.Text);
                    }
                }
                if (fieldName == "TelNo")
                {
                    myMergeField.Select();
                    // Check whether the control text is empty
                    if (txtTelephone.Text == "")
                    {
                        oWord.Selection.TypeText(" ");
                    }
                    else
                    {
                        oWord.Selection.TypeText(txtCompany.Text);
                    }
                }
                if (fieldName == "ODetails")
                {
                    myMergeField.Select();
                    // Check whether the control text is empty
                    if (txtOther.Text == "")
                    {
                        oWord.Selection.TypeText(" ");
                    }
                    else
                    {
                        oWord.Selection.TypeText(txtOther.Text);
                    }
                }
            }
        }
        oWord.Visible = false;
        // If you want your document to be saved as docx
        //Change the file Path here to a path other than your desktop
        Object savePath = @"C:\Documents and Settings\YYC\Desktop\TempWord.doc";
        //oWordDoc.Save();
        oWordDoc.SaveAs(ref savePath,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing
           );
        // Close the Word document, but leave the Word application open.
        // doc has to be cast to type _Document so that it will find the 
        // correct Close method. 
        object doNotSaveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWordDoc);
        // word has to be case to type _Application so that it will find 
        // the correct Quit method. 
        ((Word._Application)oWord).Quit(ref doNotSaveChanges, ref oMissing, ref oMissing);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWord);
    }
