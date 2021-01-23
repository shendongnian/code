            string allErrors = string.Empty;
            foreach (string err in errorList)
            {
                allErrors += err + "<br />";
            }
            if (allErrors != string.Empty)
            {
                ShowMessage(allErrors);
            }
