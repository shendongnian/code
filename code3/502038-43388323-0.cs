    static void Main(string[] args)
        {
            try
            {
                Application app = new Application();
                Document doc = app.Documents.Add();
                Range range = doc.Range(0, 0);
                range.ListFormat.ApplyNumberDefault();
                range.Text = "Birinci";
                range.InsertParagraphAfter();
                ListTemplate listTemplate = range.ListFormat.ListTemplate;
                //range.InsertAfter("Birinci");
                //range.InsertParagraphAfter();
                //range.InsertAfter("İkinci");
                //range.InsertParagraphAfter();
                //range.InsertAfter("Üçüncü");
                //range.InsertParagraphAfter();
                Range subRange = doc.Range(range.StoryLength - 1);
                subRange.ListFormat.ApplyBulletDefault();
                subRange.ListFormat.ListIndent();
                subRange.Text = "Alt Birinci";
                subRange.InsertParagraphAfter();
                ListTemplate sublistTemplate = subRange.ListFormat.ListTemplate;
                Range subRange2 = doc.Range(subRange.StoryLength - 1);
                subRange2.ListFormat.ApplyListTemplate(sublistTemplate);
                subRange2.ListFormat.ListIndent();
                subRange2.Text = "Alt İkinci";
                subRange2.InsertParagraphAfter();
                Range range2 = doc.Range(range.StoryLength - 1);
                range2.ListFormat.ApplyListTemplateWithLevel(listTemplate,true);
                WdContinue isContinue =  range2.ListFormat.CanContinuePreviousList(listTemplate);
                range2.Text = "İkinci";
                range2.InsertParagraphAfter();
                Range range3 = doc.Range(range2.StoryLength - 1);
                range3.ListFormat.ApplyListTemplate(listTemplate);
                range3.Text = "Üçüncü";
                range3.InsertParagraphAfter();
                string path = Environment.CurrentDirectory;
                int totalExistDocx = Directory.GetFiles(path, "test*.docx").Count();
                path = Path.Combine(path, string.Format("test{0}.docx", totalExistDocx + 1));
                app.ActiveDocument.SaveAs2(path, WdSaveFormat.wdFormatXMLDocument);
                doc.Close();
                Process.Start(path);
            }
            catch (Exception exception)
            {
                throw;
            }
        }
