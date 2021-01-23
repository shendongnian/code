    using w14 = DocumentFormat.OpenXml.Office2010.Word
    
                SdtRun sdtRun1 = new SdtRun();
    
                SdtProperties sdtProperties1 = new SdtProperties();
                SdtId sdtId1 = new SdtId(){ Val = -1636166143 };
    
                W14.SdtContentCheckBox sdtContentCheckBox1 = new W14.SdtContentCheckBox();
                W14.Checked checked1 = new W14.Checked(){ Val = W14.OnOffValues.Zero };
                W14.CheckedState checkedState1 = new W14.CheckedState(){ Font = "MS Gothic", Val = "2612" };
                W14.UncheckedState uncheckedState1 = new W14.UncheckedState(){ Font = "MS Gothic", Val = "2610" };
    
                sdtContentCheckBox1.Append(checked1);
                sdtContentCheckBox1.Append(checkedState1);
                sdtContentCheckBox1.Append(uncheckedState1);
    
                sdtProperties1.Append(sdtId1);
                sdtProperties1.Append(sdtContentCheckBox1);
    
                SdtContentRun sdtContentRun1 = new SdtContentRun();
    
                Run run1 = new Run();
    
                RunProperties runProperties1 = new RunProperties();
                RunFonts runFonts1 = new RunFonts(){ Hint = FontTypeHintValues.EastAsia, Ascii = "MS Gothic", HighAnsi = "MS Gothic", EastAsia = "MS Gothic" };
    
                runProperties1.Append(runFonts1);
                Text text1 = new Text();
                text1.Text = "☐";
    
                run1.Append(runProperties1);
                run1.Append(text1);
    
                sdtContentRun1.Append(run1);
