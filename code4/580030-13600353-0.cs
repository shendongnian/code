                Paragraph paragraph = new Paragraph();
                Bold bold = new Bold();
                bold.Inlines.Add(new Run() { Text = _string2FromResources });
    
                Run run = new Run();
                run.Text = _string1FromResources;
                Run run2 = new Run();
                run2.Text = _string3FromResources;
                
                paragraph.Inlines.Add(run); 
                paragraph.Inlines.Add(bold);
                paragraph.Inlines.Add(run2);
               
                rtb.Blocks.Add(paragraph);
