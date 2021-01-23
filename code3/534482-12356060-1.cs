    //For WPF:
    // var binding = BindingOperations.GetBindingBase(
    //     MyTextBlock,
    //     TextBlock.TextProperty);
    //For SilverLight we have to use the expression:
    var expr = MyTextBlock.GetBindingExpression(TextBlock.TextProperty);
    if (expr != null)
    {
        // for Silverlight we have to use the ParentBinding of the expression
        var binding = expr.ParentBinding;
        binding.Converter = yourLogicHere;
        // in WPF there are 3 types of bindings
        /*
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
        */
    }
