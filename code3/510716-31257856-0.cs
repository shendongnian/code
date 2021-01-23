            bool retry = true;
            while (retry)
            {
                try
                {
                    string textTemplate = File.ReadAllText(templatePath);
                    Razor.CompileWithAnonymous(textTemplate, templateFileName);
                    retry = false;
                }
                catch (TemplateCompilationException ex)
                {
                    LogTemplateException(templatePath, ex);
                    retry = false;
                    if (ex.Errors.Any(e  => e.ErrorNumber == "CS1969"))
                    {
                        try
                        {
                            _logger.InfoFormat("Attempting to manually load the Microsoft.CSharp.RuntimeBinder.Binder");
                            Assembly csharp = Assembly.Load("Microsoft.CSharp, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
                            Type type = csharp.GetType("Microsoft.CSharp.RuntimeBinder.Binder");
                            retry = true;
                        }
                        catch(Exception exLoad)
                        {
                            _logger.Error("Failed to manually load runtime binder", exLoad);
                        }
                    }
                    if (!retry)
                        throw;
                }
            }
