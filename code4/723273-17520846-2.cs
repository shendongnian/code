    int newaddslidecounter = 0; // checking how many new slides have to be inserted in order to split the table
    int startmultiplicator=1; // used in order to return current table row that must be pasted in new table
    int amountrowsshown =7; // amount of shown rows per table
    int fontsize = 12;
    // set position of new table/chart
    int topsize = 100;
    int leftsize = 100;
    int widthsize = 150;
    int heightsize = 150;
    Boolean alreadycreated = false; // checks if a table has already been created
    //Resizing all tables
    //and insert new Excel table instead while importing data from Excel table
    //used for visualization of data
    foreach (PowerPoint.Slide slide in presentation.Slides)
                {
                    slide.Select();
                    //loop through all shapes in slide
                    foreach (PowerPoint.Shape pptshape in slide.Shapes)
                    {
                        //Console.WriteLine("Shape type : " + pptshape.Type.ToString());
                        //check if current shape is a table
                        //in order to do the manipulation
                        if (pptshape.Type.ToString().Equals("msoTable"))
                        {
                            for (int i = 1; i <= pptshape.Table.Rows.Count; i++)
                            {
                                for (int j = 1; j <= pptshape.Table.Columns.Count; j++)
                                {
                                    /// checks if the module of the current row and the amount of maximum
                                    /// shown rows to be visible in table is the same
                                    // Console.WriteLine("row= " + i + " col= " + j);
                                    if ((i % amountrowsshown) == 0 && alreadycreated == false)
                                    {
                                        PowerPoint.Table objTable = null;
                                        /// Add new slide if table requires more than one slide
                                        if (newaddslidecounter == 0)
                                        {
                                            /// Add new table object in the slide                                        
                                            objTable = presentation.Slides[slide.SlideIndex].Shapes.AddTable(amountrowsshown, pptshape.Table.Columns.Count, topsize, leftsize, slide.Master.Width - widthsize, slide.Master.Height - heightsize).Table;
                                        }
                                        else
                                        {
                                            presentation.Slides.Add(slide.SlideIndex + newaddslidecounter, NetOffice.PowerPointApi.Enums.PpSlideLayout.ppLayoutClipArtAndVerticalText);
                                            /// Add new table object in the slide                                        
                                            objTable = presentation.Slides[slide.SlideIndex + newaddslidecounter].Shapes.AddTable(amountrowsshown, pptshape.Table.Columns.Count, topsize, leftsize, slide.Master.Width - widthsize, slide.Master.Height - heightsize).Table;
                                        }
                                        int incrementer = 1;
                                        /// Run through the created new table and paste all the previous table values
                                        for(int k=startmultiplicator;k<=i;k++)
                                        {
                                            for(int l=1;l<=pptshape.Table.Columns.Count;l++)
                                            {
                                               objTable.Cell(incrementer,l).Shape.TextFrame.TextRange.Text=pptshape.Table.Cell(k,l).Shape.TextFrame.TextRange.Text;
                                               objTable.Cell(incrementer, l).Shape.TextFrame.TextRange.Font.Size = fontsize;
                                            }
                                            incrementer++;
                                        }
                                        startmultiplicator += amountrowsshown;
                                        alreadycreated = true;
                                        newaddslidecounter++;
                                    }
                                }
                                alreadycreated = false;
                            }
                            /// In case is still some rows left which haven't been considered
                            /// we copy those in a new table
                            //Console.WriteLine("Create new table before leaving");
                           // Console.WriteLine(startmultiplicator);
                            if (startmultiplicator <= pptshape.Table.Rows.Count)
                            {
                                PowerPoint.Table objTable = null;
                                if (startmultiplicator < amountrowsshown)
                                {
                                    /// Add new table object in the slide
                                    objTable = presentation.Slides[slide.SlideIndex].Shapes.AddTable(amountrowsshown, pptshape.Table.Columns.Count, topsize, leftsize, slide.Master.Width - widthsize, slide.Master.Height - heightsize).Table;    
                                }
                                else
                                {
                                    /// Don't add new slide for last rows
                                    presentation.Slides.Add(slide.SlideIndex + newaddslidecounter, NetOffice.PowerPointApi.Enums.PpSlideLayout.ppLayoutClipArtAndVerticalText);
                                    // Add new table object in the slide
                                    objTable = presentation.Slides[slide.SlideIndex + newaddslidecounter].Shapes.AddTable(amountrowsshown, pptshape.Table.Columns.Count, topsize, leftsize, slide.Master.Width - widthsize, slide.Master.Height - heightsize).Table;
                                }
                                int incrementer = 1;
                                /// Run through the created new table and paste all the previous table values
                                for (int k = startmultiplicator; k <= pptshape.Table.Rows.Count; k++)
                                {
                                    for (int l = 1; l <= pptshape.Table.Columns.Count; l++)
                                    {
                                        objTable.Cell(incrementer, l).Shape.TextFrame.TextRange.Text = pptshape.Table.Cell(k, l).Shape.TextFrame.TextRange.Text;
                                        objTable.Cell(incrementer, l).Shape.TextFrame.TextRange.Font.Size = fontsize;
                                    }
                                    incrementer++;
                                }
                                objTable.Application.Top = topsize;
                                objTable.Application.Left = leftsize;
                                objTable.Application.Width = slide.Master.Width - widthsize;
                                objTable.Application.Height = slide.Master.Height - heightsize;
                            }
                            pptshape.Delete();
                        }
                        
                    }
                    newaddslidecounter=0;
                    startmultiplicator=1;
                }
