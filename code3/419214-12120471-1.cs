                var rubyEngine = Ruby.CreateEngine();
                ScriptSource src = rubyEngine.CreateScriptSourceFromFile("test.rb");
                IronRubyErrors error = new IronRubyErrors();
                src.Compile(error);
                if (error.ErrorCode != 0)
                {
                    MessageBox.Show(string.Format("Discription {0} \r\nError at Line No.{1} and Column No{2}", error.Message, error.span.Start.Line, error.span.Start.Column));
                }
                try
                {
                    if (error.ErrorCode == 0)
                    {
                        var res = src.Execute();
                    }
                }
                catch (MissingMethodException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
