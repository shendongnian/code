    using System;
    using System.Collections.Generic;
    using System.Drawing.Design;
    using System.Windows.Forms.Design;
    
    namespace PropertyGrid_ListBox_Test
    {
        class TypeCodeEditor : UITypeEditor
        {
            public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
            {
                return UITypeEditorEditStyle.DropDown;
            }
    
            public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                IWindowsFormsEditorService editorService = null;
                if (provider != null)
                {
                    editorService = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
                }
    
                if (editorService != null)
                {
                    TypeCodeSelectionControl selectionControl = new TypeCodeSelectionControl((List<TypeCodes>)value, editorService);
                    editorService.DropDownControl(selectionControl);
    
                    value = selectionControl.List;
                }
    
                return value;
            }
        }
    }
