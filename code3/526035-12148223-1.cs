         context.Dialogs.Add( new Dialog
         {
            Id = 1,
            Chapter = 1,
            Index = 0,
            DialogColor = "default-color",
            DialogText = "blah blah!",
            Character = "none",
            Transition = false,
            Fade = true,
            Timer = 0,
            Actions = new List<Action>
                {
                    context.Actions.Add(new Action()
                                           {
                                              ActionText = "--continue--",
                                              ActionLink = 1, Id=1 
                                           })
                }
         } );
