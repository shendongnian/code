        private void ListMethods()
        {
            CodeNamespace codenamespace = null;
            for(int i = 1; i <= _applicationObject.ActiveWindow.ProjectItem.FileCodeModel.CodeElements.Count; i++)
            {
                if(_applicationObject.ActiveWindow.ProjectItem.FileCodeModel.CodeElements.Item(i).Kind == vsCMElement.vsCMElementNamespace)
                {
                    codenamespace = (CodeNamespace)_applicationObject.ActiveWindow.ProjectItem.FileCodeModel.CodeElements.Item(i);
                }
            }
            for(int i = 1; i <= codenamespace.Members.Count; i++)
            {
                if(codenamespace.Members.Item(i) is CodeClass)
                {
                    ListMethodsForClass(codenamespace.Members.Item(i) as CodeClass);
                }
            }
        }
        private void ListMethodsForClass(CodeClass codeclass)
        {
            for (int i = 1; i <= codeclass.Members.Count; i++)
            {
                message(codeclass.Members.Item(i).Name);
            }
        }
