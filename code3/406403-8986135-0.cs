            // Creates an SharedStringItem instance and adds its children.
            public SharedStringItem GenerateSharedStringItem()
            {
                SharedStringItem sharedStringItem1 = new SharedStringItem();
    
                Run run1 = new Run();
    
                RunProperties runProperties1 = new RunProperties();
                Bold bold1 = new Bold();
                Underline underline1 = new Underline();
                FontSize fontSize1 = new FontSize(){ Val = 11D };
                Color color1 = new Color(){ Theme = (UInt32Value)1U };
                RunFont runFont1 = new RunFont(){ Val = "Calibri" };
                FontFamily fontFamily1 = new FontFamily(){ Val = 2 };
                FontScheme fontScheme1 = new FontScheme(){ Val = FontSchemeValues.Minor };
    
                runProperties1.Append(bold1);
                runProperties1.Append(underline1);
                runProperties1.Append(fontSize1);
                runProperties1.Append(color1);
                runProperties1.Append(runFont1);
                runProperties1.Append(fontFamily1);
                runProperties1.Append(fontScheme1);
                Text text1 = new Text();
                text1.Text = "Project Name:";
    
                run1.Append(runProperties1);
                run1.Append(text1);
    
                Run run2 = new Run();
    
                RunProperties runProperties2 = new RunProperties();
                FontSize fontSize2 = new FontSize(){ Val = 11D };
                Color color2 = new Color(){ Theme = (UInt32Value)1U };
                RunFont runFont2 = new RunFont(){ Val = "Calibri" };
                FontFamily fontFamily2 = new FontFamily(){ Val = 2 };
                FontScheme fontScheme2 = new FontScheme(){ Val = FontSchemeValues.Minor };
    
                runProperties2.Append(fontSize2);
                runProperties2.Append(color2);
                runProperties2.Append(runFont2);
                runProperties2.Append(fontFamily2);
                runProperties2.Append(fontScheme2);
                Text text2 = new Text(){ Space = SpaceProcessingModeValues.Preserve };
                text2.Text = " ALLAN";
    
                run2.Append(runProperties2);
                run2.Append(text2);
    
                sharedStringItem1.Append(run1);
                sharedStringItem1.Append(run2);
                return sharedStringItem1;
            }
