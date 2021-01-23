     void radGridView1_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            RadDropDownListEditor editor = e.ActiveEditor as RadDropDownListEditor;
            if (editor != null)
            {
                editor.DropDownStyle = RadDropDownStyle.DropDown;
                RadDropDownListEditorElement element = (RadDropDownListEditorElement)editor.EditorElement;
                element.VisualItemFormatting -= element_VisualItemFormatting;
                element.AutoCompleteSuggest.DropDownList.VisualItemFormatting -= element_VisualItemFormatting;
                //this handles the default drop down formatting - when you press the arrow key to open the drop down
                element.VisualItemFormatting += element_VisualItemFormatting;
                //this handles the suggest popup formatting
                element.AutoCompleteSuggest.DropDownList.VisualItemFormatting += element_VisualItemFormatting;
            }
        }
        void element_VisualItemFormatting(object sender, VisualItemFormattingEventArgs args)
        {
            args.VisualItem.Font = new Font("Arial", 16);
        }
