    Public Partial Class TreeTable_Form
        // Sorry. The "WithEvents" in C# is a litte bit complex to me... So, in VB :
        Protected WithEvents _CellEditor As CellEditor_Form = Nothing
        // ...
        
        // CellEditor handling method (I used a Code converter...) :
        // The original VB declaration is :
        // Protected Sub RecallFormAfterCellEditorHidden() Handles _CellEditor.Closed
        // You'll have to write specific Event handler for _CellEditor object declared above...
        protected void RecallFocusAfterCellEditorHidden()
        {
            Application.DoEvents();
            this.Focus();
        }
        
    End Class
