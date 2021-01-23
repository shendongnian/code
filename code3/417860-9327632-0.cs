    //initialize
    Application WordApp = new Application();
    Document adoc = WordApp.Documents.Add();
    Selection selection = adoc.ActiveWindow.Selection;
    Shape wmShape;
    object missing = System.Reflection.Missing.Value;
    object linktofile = false;
    object savewithdocument = true;
    object CurrentPage = WdFieldType.wdFieldPage;
    object TotalPages = WdFieldType.wdFieldNumPages;
    
    //load background images
    List<string> images = new List<string>();
    images.Add(@"C:\Users\Public\Pictures\Sample Pictures\Chrysanthemum.jpg");
    images.Add(@"C:\Users\Public\Pictures\Sample Pictures\Desert.jpg");
    images.Add(@"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg");
    images.Add(@"C:\Users\Public\Pictures\Sample Pictures\Hydrangeas.jpg");
    images.Add(@"C:\Users\Public\Pictures\Sample Pictures\Jellyfish.jpg");
    images.Add(@"C:\Users\Public\Pictures\Sample Pictures\Penguins.jpg");
    images.Add(@"C:\Users\Public\Pictures\Sample Pictures\Tulips.jpg");
    images.Add(@"C:\Users\Public\Pictures\Sample Pictures\Lighthouse.jpg");
    
    //create all sections
    object breaktype = WdBreakType.wdSectionBreakNextPage;
    for (int i = 0; i < images.Count - 1; i++)
    {
    	adoc.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekMainDocument;
    	selection.InsertBreak(ref breaktype);
    	adoc.ActiveWindow.ActivePane.View.SeekView = WdSeekView.wdSeekCurrentPageHeader;
    	selection.HeaderFooter.LinkToPrevious = false;
    }
    
    //set background images
    for (int i = 0; i < adoc.Sections.Count; i++)
    {
    	//select section header
    	adoc.Sections[i+1].Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Select();
    
    	//insert pagenumbers
    	adoc.ActiveWindow.ActivePane.Selection.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
    	selection.TypeText("Pagina ");
    	selection.Fields.Add(selection.Range, ref CurrentPage, ref missing, ref missing);
    	selection.TypeText(" van ");
    	selection.Fields.Add(selection.Range, ref TotalPages, ref missing, ref missing);
    
    	//insert shape
    	wmShape = selection.InlineShapes.AddPicture(images[i], ref linktofile, ref savewithdocument).ConvertToShape();
    
    	//modify shape properties
    	wmShape.Select(ref missing);
    	wmShape.Name = "WordPictureWatermark862903805";
    	wmShape.PictureFormat.Brightness = (float)0.5;
    	wmShape.PictureFormat.Contrast = (float)0.5;
    	wmShape.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoFalse;
    	wmShape.Height = WordApp.InchesToPoints((float)11.7);
    	wmShape.Width = WordApp.InchesToPoints((float)8.3);
    	wmShape.WrapFormat.AllowOverlap = -1;
    	wmShape.WrapFormat.Side = WdWrapSideType.wdWrapBoth;
    	wmShape.WrapFormat.Type = WdWrapType.wdWrapBehind;
    	wmShape.RelativeHorizontalPosition = WdRelativeHorizontalPosition.wdRelativeHorizontalPositionMargin;
    	wmShape.RelativeVerticalPosition = WdRelativeVerticalPosition.wdRelativeVerticalPositionMargin;
    	wmShape.Left = (float)WdShapePosition.wdShapeCenter;
    	wmShape.Top = (float)WdShapePosition.wdShapeCenter;
    
    }
    
    WordApp.Visible = true;
