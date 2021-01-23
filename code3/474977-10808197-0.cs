    public sealed class RuleSequenceAcitvity : NativeActivity<Sequence>
    {
        private DynamicActivity _dynamicActivity;
        public InArgument<HomeIndexViewModel> Model { get; set; }
    
        protected override void Execute(NativeActivityContext context)
        {
            populateDynamicActivity();
    
            var input = new Dictionary<string, object>();
            
            // It was throwing a null reference because Model
            // was private, so the input that the activity was receiving 
            // was never binded to it.
    
            var model = context.GetValue<HomeIndexViewModel>(this.Model);
            input.Add("Model", model);
    
            // It's the dynamic activity that contains input arguments.
            // Not the sequence. 
    
            WorkflowInvoker.Invoke(_dynamicActivity, input);
        }
    
        private void populateDynamicActivity()
        {
            //get the list of rules from repository
            var rules = 
                ObjectFactory
                .Container
                .GetInstance<IRuleRepository>()
                .Rules
                .ToList();
    
            //Declare a dynamic property as the view model
            var inProperty = new DynamicActivityProperty
            {
                Name = "Model",
                Type = typeof(InArgument<HomeIndexViewModel>)
            };
            
            _dynamicActivity = new DynamicActivity() 
            { 
                Properties = { inProperty } 
            };
    
            //Import references
            Common.AddVbSetting(activity);
    
            var sequence = new Sequence();
            activity.Implementation = () => sequence
    
            //Sort Descending - those added first are lowest priority
            var sortedRules = rules.OrderBy(x => x.Priority).ToList();
    
            foreach (var inRule in rules)
            {
                var outRule = RuleConverter.ToIfActivity(inRule);
                sequence.Activities.Add(outRule);
            }
    
        }
    }
