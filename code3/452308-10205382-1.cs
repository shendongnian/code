    #if DEBUG
    namespace MyNamespace
    {
        using System;
     
     
        public partial class CustomerEditorControl_Design : BaseEditorControl<Customer>
        {
            public CustomerEditorControl_Design()
                : base()
            {
                InitializeComponent();
            }
        }
    }
     
    #endif
    
        public partial class CustomerEditorControl
    #if DEBUG
            : CustomerEditorControl_Design
    #else
            : BaseEditorControl<Customer>
    #endif
        {
        }
