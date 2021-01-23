        var mNamespace = new StackTrace().GetFrames()?.Select(x =>
                    {
                        try
                        {
                            return x.GetMethod().ReflectedType?.Namespace;
                        }
                        catch (Exception)
                        {
                            return string.Empty;
                        }
                    }).First(x => x != new StackTrace().GetFrame(0).GetMethod().ReflectedType?.Namespace);
