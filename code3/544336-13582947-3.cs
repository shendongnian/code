    public class CustomFileUpload
    {
        private readonly IntPtr _browserHandle;
        private readonly string _tabHeader;
        public CustomFileUpload(IntPtr browserHandle, string tabHeader)
        {
            _browserHandle = browserHandle;
            _tabHeader = tabHeader;
        }
        public void Set(string filePath)
        {
            Automate(filePath);
        }
        private void Automate(string filePath)
        {
            AutomationElement browser = AutomationElement.FromHandle(_browserHandle);
            AutomationElement tab = FindTab(browser, _tabHeader);
            // IE10 adds the name (or value?) "Browse..." to the upload-button. Need to hack it :)
            AutomationElement uploadButton = tab.FindFirst(TreeScope.Children,
                                                                new AndCondition(
                                                                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
                                                                    new PropertyCondition(AutomationElement.NameProperty, "Browse..."))) ??
                                                                    tab.FindFirst(TreeScope.Children,
                                                            new AndCondition(
                                                                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
                                                                new PropertyCondition(AutomationElement.NameProperty, "")));
            ClickButton(uploadButton);
            var openFileDialog = WaitUntilOpenFileDialogAvailable();
            var valuePattern = FindFileNameTextBox(openFileDialog).GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            if (valuePattern == null)
                throw new InvalidOperationException("Can't set the file path");
            valuePattern.SetValue(filePath);
            SetFocusToSomethingElse(browser);
            var okButton = WaitUntilOkButtonLoaded(openFileDialog);
            ClickButton(okButton);
        }
        private static AutomationElement FindTab(AutomationElement browser, string tabHeader)
        {
            return browser.FindFirst(TreeScope.Descendants,
                                     new AndCondition(
                                         new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Pane),
                                         new PropertyCondition(AutomationElement.NameProperty, tabHeader)));
        }
        private static void SetFocusToSomethingElse(AutomationElement elementWhichShouldNotBeSelected)
        {
            do
            {
                foreach (AutomationElement element in AutomationElement.RootElement.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.IsKeyboardFocusableProperty, true)))
                {
                    if (element != elementWhichShouldNotBeSelected)
                    {
                        element.SetFocus();
                        return;
                    }
                }
            } while (true);
        }
        private static AutomationElement WaitUntilOkButtonLoaded(AutomationElement openFileDialog)
        {
            AutomationElement okButton;
            do
            {
                okButton = openFileDialog.FindFirst(TreeScope.Children,
                                                    new AndCondition(
                                                        new PropertyCondition(AutomationElement.IsContentElementProperty, true),
                                                        new PropertyCondition(AutomationElement.IsControlElementProperty, true),
                                                        new PropertyCondition(AutomationElement.NameProperty, "Open"),
                                                        new PropertyCondition(AutomationElement.IsInvokePatternAvailableProperty, true)
                                                        ));
            } while (okButton == null);
            return okButton;
        }
        private static AutomationElement WaitUntilOpenFileDialogAvailable()
        {
            AutomationElement openFileDialog = null;
            do
            {
                AutomationElement openFileDialogContainer = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "Alternate Modal Top Most"));
                if (openFileDialogContainer != null)
                    openFileDialog = openFileDialogContainer.FindFirst(TreeScope.Children, Condition.TrueCondition);
            } while (openFileDialog == null);
            return openFileDialog;
        }
        private static void ClickButton(AutomationElement button)
        {            
            var clickPattern = button.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            if (clickPattern == null)
                throw new InvalidOperationException("Can't find the buttons click pattern");
            clickPattern.Invoke();
        }
        private static AutomationElement FindFileNameTextBox(AutomationElement openFileDialog)
        {
            AutomationElement findElementToTypePathInto;
            do
            {
                findElementToTypePathInto = openFileDialog.FindFirst(TreeScope.Descendants, new AndCondition(new PropertyCondition(AutomationElement.NameProperty, "File name:"), new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit)));
            } while (findElementToTypePathInto == null);
            return findElementToTypePathInto;
        }
    }
