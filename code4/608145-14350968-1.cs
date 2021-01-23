    //Write method to get window element for the window you wish to manipulate
    //Open an instance of notepad and the WindowTitle is: "Untitled - Notepad"
    //you could use other means of getting to the Window element ...
    AutomationElement windowElement = getWindowElement("Untitled - Notepad");
    //Use System.Windows.Automation to find all radio buttons in the WindowElement
    //pass the window element into this method
    //This method will return all of the radio buttons in the element that is passed in
    //however, if you have a Pane inside of the WIndow and then, the buttons are contained
    //in the pane, you will have to get to the pane and then pass the pane into the findradiobuttons method
    AutomationElementCollection radioButtons = FindRadioButtons(windowElement);
    //could iterate through the radioButtons to determine which is selected...
    //then select the next index etc.    
    //then programmatically select the radio button
    //pass the selected radioButton AutomationElement into a method that Invokes the Click etc.
    clickButtonUsingUIAutomation(radioButtons[0]);
    /// <summary> 
    /// Finds all enabled buttons in the specified window element. 
    /// </summary> 
    /// <param name="elementWindowElement">An application or dialog window.</param>
    /// <returns>A collection of elements that meet the conditions.</returns>
    AutomationElementCollection FindRadioButtons(AutomationElement elementWindowElement)
    {
        if (elementWindowElement == null)
        {
            throw new ArgumentException();
        }
        Condition conditions = new AndCondition(
          new PropertyCondition(AutomationElement.IsEnabledProperty, true),
          new PropertyCondition(AutomationElement.ControlTypeProperty, 
              ControlType.RadioButton)
          );
        // Find all children that match the specified conditions.
        AutomationElementCollection elementCollection = 
        elementWindowElement.FindAll(TreeScope.Children, conditions);
        return elementCollection;
    }
        private AutomationElement getWindowElement(string windowTitle)
        {
            AutomationElement root = AutomationElement.RootElement;
            AutomationElement result = null;
            foreach (AutomationElement window in root.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window)))
            {
                try
                {
                    if (window.Current.Name.Contains(windowTitle) && window.Current.IsKeyboardFocusable)
                    {
                        result = window;
                        break;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return result;
        }
        private void ClickButtonUsingUIAutomation(AutomationElement control)
        {
            // Test for the control patterns of interest for this sample. 
            object objPattern;
            ExpandCollapsePattern expcolPattern;
            if (true == control.TryGetCurrentPattern(ExpandCollapsePattern.Pattern, out objPattern))
            {
                expcolPattern = objPattern as ExpandCollapsePattern;
                if (expcolPattern.Current.ExpandCollapseState != ExpandCollapseState.LeafNode)
                {
                    Button expcolButton = new Button();
                    //expcolButton.Margin = new Thickness(0, 0, 0, 5);
                    expcolButton.Height = 20;
                    expcolButton.Width = 100;
                    //expcolButton.Content = "ExpandCollapse";
                    expcolButton.Tag = expcolPattern;
                    expcolPattern.Expand();
                    //SelectListItem(control, "ProcessMethods");
                    //expcolButton.Click += new RoutedEventHandler(ExpandCollapse_Click);
                    //clientTreeViews[treeviewIndex].Children.Add(expcolButton);
                }
            }
            TogglePattern togPattern;
            if (true == control.TryGetCurrentPattern(TogglePattern.Pattern, out objPattern))
            {
                togPattern = objPattern as TogglePattern;
                Button togButton = new Button();
                //togButton.Margin = new Thickness(0, 0, 0, 5);
                togButton.Height = 20;
                togButton.Width = 100;
                //togButton.Content = "Toggle";
                togButton.Tag = togPattern;
                togPattern.Toggle();
                //togButton.Click += new RoutedEventHandler(Toggle_Click);
                //clientTreeViews[treeviewIndex].Children.Add(togButton);
            }
            InvokePattern invPattern;
            if (true == control.TryGetCurrentPattern(InvokePattern.Pattern, out objPattern))
            {
                invPattern = objPattern as InvokePattern;
                Button invButton = new Button();
                //invButton.Margin = new Thickness(0);
                invButton.Height = 20;
                invButton.Width = 100;
                //invButton.Content = "Invoke";
                invButton.Tag = invPattern;
                //invButton.Click += new EventHandler(Invoke_Click);
                invPattern.Invoke();
                //clientTreeViews[treeviewIndex].Children.Add(invButton);
            }
        }
