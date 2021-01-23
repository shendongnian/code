    Sub MapEventToCommand(eventNameSource As String, commandDestination As string)
            Dim t = New InvokeCommandAction()
            Dim commandAction As New InvokeCommandAction()
            Dim actionCommandBinding As New Binding(commandDestination)
            BindingOperations.SetBinding(commandAction, InvokeCommandAction.CommandProperty, actionCommandBinding)
            Dim eventTrigger As New EventTrigger(eventNameSource)
            eventTrigger.Actions.Add(commandAction)
            Interaction.GetTriggers(Me).Add(eventTrigger)
        End Sub
