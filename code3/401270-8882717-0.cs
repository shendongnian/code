    try
    {
        Razor.Parse("My erroneous @DateTime.Now.foo()");
    }
    catch(TemplateCompilationException ex)
    {
        foreach(var error in ex.Errors)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Compile Error Num: \t" + error.ErrorNumber);
            sb.AppendLine("Error Text:\n\t" + error.ErrorText);
            Console.WriteLine(sb.ToString());
        }
        Console.WriteLine("Erroneous Template:\n\t" + ex.Template);
    }
