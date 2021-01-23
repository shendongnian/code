    private T GetOrCreateWorksheetChildCollection<T>(Spreadsheet.Worksheet worksheet) 
    	where T : OpenXmlCompositeElement, new()
    {
    	T collection = worksheet.GetFirstChild<T>();
    	if (collection == null)
    	{
    		collection = new T();
    		if (!worksheet.HasChildren)
    		{
    			worksheet.AppendChild(collection);
    		}
    		else
    		{
    			// compute the positions of all child elements (existing + new collection)
    			List<int> schemaPositions = worksheet.ChildElements
    				.Select(e => _childElementNames.IndexOf(e.LocalName)).ToList();
    			int collectionSchemaPos = _childElementNames.IndexOf(collection.LocalName);
    			schemaPositions.Add(collectionSchemaPos);
    			schemaPositions = schemaPositions.OrderBy(i => i).ToList();
    
    			// now get the index where the position of the new child is
    			int index = schemaPositions.IndexOf(collectionSchemaPos);
    
    			// this is the index to insert the new element
    			worksheet.InsertAt(collection, index);
    		}
    	}
    	return collection;
    }
    
    // names and order of possible child elements according to the openXML schema
    private static readonly List<string> _childElementNames = new List<string>() { 
    	"sheetPr", "dimension", "sheetViews", "sheetFormatPr", "cols", "sheetData", 
    	"sheetCalcPr", "sheetProtection", "protectedRanges", "scenarios", "autoFilter",
    	"sortState", "dataConsolidate", "customSheetViews", "mergeCells", "phoneticPr",
    	"conditionalFormatting", "dataValidations", "hyperlinks", "printOptions", 
    	"pageMargins", "pageSetup", "headerFooter", "rowBreaks", "colBreaks", 
    	"customProperties", "cellWatches", "ignoredErrors", "smartTags", "drawing",
    	"drawingHF", "picture", "oleObjects", "controls", "webPublishItems", "tableParts",
    	"extLst"
    };
