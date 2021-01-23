            private Trigger CreateTrigger()
            {
                Trigger trigger = new Trigger
                {
                    Property = StopAnimatingProperty,
                    Value = false,
                };
                
                trigger.EnterActions.Add(_beginStoryBoard);
                trigger.ExitActions.Add(_removeStoryboard);
                return trigger;
            }
