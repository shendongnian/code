        foreach (CodeElement codeElement in projectItem.FileCodeModel.CodeElements)// search for the function to be opened
        {
            // get the namespace elements
            if (codeElement.Kind == vsCMElement.vsCMElementNamespace)
            {
                foreach (CodeElement namespaceElement in codeElement.Children)
                {
                    // get the class elements
                    if (namespaceElement.Kind == vsCMElement.vsCMElementClass || namespaceElement.Kind == vsCMElement.vsCMElementInterface)
                    {
                        foreach (CodeElement classElement in namespaceElement.Children)
                        {
                            try
                            {
                                // get the function elements to highlight methods in code window
                                if (classElement.Kind == vsCMElement.vsCMElementFunction)
                                {
                                    if (!string.IsNullOrEmpty(highlightString))
                                    {
                                        if (classElement.Name.Equals(highlightString, StringComparison.Ordinal))
                                        {
                                            classElement.StartPoint.TryToShow(vsPaneShowHow.vsPaneShowTop, null);
                        classElement.StartPoint.TryToShow(vsPaneShowHow.vsPaneShowTop, null);
                            // get the text of the document
                         EnvDTE.TextSelection textSelection = window.Document.Selection as EnvDTE.TextSelection;
                            // now set the cursor to the beginning of the function
                            textSelection.MoveToPoint(classElement.StartPoint);
                            textSelection.SelectLine();
                                        }
                                    }
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
        }
