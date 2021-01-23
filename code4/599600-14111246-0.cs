    using System.Windows.Automation;
    
    class Program
    {
     public static void Main()
     {
      var calcWindow = AutomationElement.RootElement.FindFirst(
       TreeScope.Children,
       new PropertyCondition(AutomationElement.NameProperty, "Calculator"));
      if (calcWindow == null) return;
    
      var sevenButton = calcWindow.FindFirst(TreeScope.Descendants,
       new PropertyCondition(AutomationElement.NameProperty, "7"));
    
      var invokePattern = sevenButton.GetCurrentPattern(InvokePattern.Pattern)
                         as InvokePattern;
      invokePattern.Invoke();
     }
    }
