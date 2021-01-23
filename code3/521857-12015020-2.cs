    public static class MyMvcHelpers
    {
        public static IMyClass CustomHtmlTag(this HtmlHelper helper, MyModel viewModel, Action<MyModel> action)
        {
            action.Invoke(viewModel);
            var expressionResult = viewModel.ValuesToString();
            
            return new MyClass(expressionResult);
        }
    }
