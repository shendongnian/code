    var binding = BindingOperations.GetBindingBase(
        MyTextBlock,
        TextBlock.TextProperty);
    if (binding != null)
    {
        // 3 types of bindings, choose the right one
        if (binding is Binding)
        {
            ((Binding)binding).Converter = yourLogicHere;
        }
        else if (binding is MultiBinding)
        {
            ((MultiBinding)binding).Converter = yourMultiLogicHere;
        }
        else if (binding is PriorityBinding)
        {
            foreach (var childBinding in ((PriorityBinding)binding).Bindings)
            {
                ((Binding)childBinding).Converter = yourLogicHere;
            }
        }
    }
