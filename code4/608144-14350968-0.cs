    //Write method to get window element for the window you wish to manipulate
    AutomationElement windowElement = getWindowElement("notepad.exe");
    //Use System.Windows.Automation to find all radio buttons in the WindowElement
    //pass the window element into this method
    AutomationElementCollection radioButtons = FindRadioButtons(windowElement);
    //could iterate through the radioButtons to determine which is selected...
    //then select the next index etc.    
    //then programmatically select the radio button
    //pass the selected radioButton AutomationElement into a method that Invokes the Click etc.
    selectRadioButton(radioButtons[0]);
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
