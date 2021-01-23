    public class SwitchAction{
      public Func<bool> Predicate { get; set; }
      public Action TheAction { get; set; }
    }
    public List<SwitchAction> SwitchableActions = new List<SwitchAction>();
    public void InitialiseSwitchableActions()
    {
       SwitchableActions.AddRange(new[] {
         new SwitchAction() { Predicate = () => Name.Text == string.Empty, 
                              TheAction = () => Name.Background = Brushes.LightSteelBlue },
         new SwitchAction() { Predicate = () => Age.Text == string.Empty, 
                              TheAction = () => Age.Background = Brushes.LightSteelBlue },
       });
    }
    public void RunSwitchables()
    {
      var switched = SwitchableActions.FirstOrDefault(s => Predicate());
      if(switched != null)
        switched.TheAction();
      else
        //TODO: something else.
    }
