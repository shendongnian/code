     Variable<string> name = new Variable<string>
                {
                    Name = "name"
                };
    
                wf = new Sequence
                {
                    Variables =
                    {
                      name
                    },
                    Activities =
                    {
                         new WriteLine()
                         {
                             Text = "Workflow Triggered"
                         },    
                         new Delay()
                         {
                             Duration = TimeSpan.FromSeconds(10)
                         },
                         new WriteLine()
                         {
                             Text = "Activity1 Completed"
                         },
                     }
                 };
