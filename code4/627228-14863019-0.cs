     ListOfForms = 
         (from form in doc3.Descendants("form")
          select new ScanBandForm() {
              FormTypes = (string)form.Attribute("types"),
              ScanBandNumber = (string)form.Attribute("number"),
              ListOfRows = 
                  (from row in form.Descendants("row")
                   select new ScanBandRow() {
                       AllowSpaces = (bool)row.Element("allowSpaces"),
                       SplitCharacter = (string)row.Element("splitCharacter"),
                       ListOfColumns = 
                          (from column in row.Descendants("column")  
                           select new ScanBandColumn() {
                                AlwaysKey = (bool)column.Element("allwaysKey"),
                                DataTypeString = (string)column.Element("dataType") ?? String.Empty                    
                                MatchingFieldName = (string)column.Element("matchingFieldName") ?? String.Empty,
                                NonField = (bool)column.Element("nonField"),
                                RegularExpressionString = (string)column.Element("regularExpression") ?? String.Empty,
                           }).ToList()
                    }).ToList()
          }).ToList()
