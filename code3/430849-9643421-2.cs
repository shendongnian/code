    public class when_extension_method_is_used
    {
        static MvcHtmlString output;
    
        Because of = () =>
        {    
            var htmlHelper = new HtmlHelper(new ViewContext(), new ViewPage());
            MyExtensionMethods.Renderer = (html, model) =>
            {
                const string template = "<blink>@Model</blink>";
                var executionResult = InMemoryRazorEngine.Execute(template, model);
                return new MvcHtmlString(executionResult.RuntimeResult);
            };
    
            output = htmlHelper.MyMethod();
        };
    
        It should_just_work =
            () => output.ToString().ShouldEqual("<blink>make UX experts cry!</blink>");
    	}
    }
