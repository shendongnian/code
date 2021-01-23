    private void AddCustomProperty(Microsoft.Office.Interop.Visio.Shape shape, string PropertyName, String propertyValue)
            {
                try
                {
    
                    short customProps = (short)VisSectionIndices.visSectionProp;      
            
                    short rowNumber = shape.AddRow(customProps, (short)VisRowIndices.visRowLast, (short)VisRowTags.visTagDefault);
    
                    shape.CellsSRC[customProps, rowNumber, (short)VisCellIndices.visCustPropsLabel].FormulaU = "\"" + PropertyName + "\"";
    
                    shape.CellsSRC[customProps, rowNumber, (short)VisCellIndices.visCustPropsValue].FormulaU = "\"" + propertyValue + "\"";
    
                    
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Error: " + e.Message);
                }
    
            }
