    public class mySignalRHub: Hub
    {
        public string getTableHTML()
        {
            var viewModel = new[] { new DataItem { Value1 = "v1", Value2 = "v2" } };
        
            var template = File.ReadAllText(Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                @"Views\PathToTablePartialView\_MyTablePartialView.cshtml"));
    
            return Engine.Razor.RunCompile(template, "templateKey", null, viewModel);
        }
    }
