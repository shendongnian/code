    public abstract class BasePresenter
        <VM, V>
        where VM : BaseViewModel
        where V : IBaseView, new()
    {
        protected void wireEventsTo(IBaseView view)
        {
            Type presenterType = this.GetType();
            Type viewType = view.GetType();
            foreach (var method in presenterType.GetMethods())
            {
                var methodName = method.Name;
                if (methodName.StartsWith("On"))
                {
                    try
                    {
                        var presenterMethodName = methodName.Substring(2);
                        var nameOfMemberToMatch = presenterMethodName.Replace("Changed", ""); //ListBoxes wiring
                        var matchingMember = viewType.GetMember(nameOfMemberToMatch).FirstOrDefault();
                        if (matchingMember == null)
                        {
                            return;
                        }
                        if (matchingMember.MemberType == MemberTypes.Event)
                        {
                            wireMethod(view, matchingMember, method);    
                        }
                        
                        if (matchingMember.MemberType == MemberTypes.Property)
                        {
                            wireMember(view, matchingMember, method);    
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
        }
        private void wireMember(IBaseView view, MemberInfo match, MethodInfo method)
        {
            var matchingMemberType = ((PropertyInfo)match).PropertyType;
            if (matchingMemberType == typeof(Button))
            {
                var matchingButton = view.Get<Button>(match.Name);
                var eventHandler = (EventHandler)EventHandler.CreateDelegate(typeof(EventHandler), this, method);
                matchingButton.Click += eventHandler;
            }
            if (matchingMemberType == typeof(ListBox))
            {
                var matchinListBox = view.Get<ListBox>(match.Name);
                var eventHandler = (EventHandler)EventHandler.CreateDelegate(typeof(EventHandler), this, method);
                matchinListBox.SelectedIndexChanged += eventHandler;
            }
        }
        private void wireMethod(IBaseView view, MemberInfo match, MethodInfo method)
        {
            var viewType = view.GetType();
            var matchingEvent = viewType.GetEvent(match.Name);
            if (matchingEvent != null)
            {
                if (matchingEvent.EventHandlerType == typeof(EventHandler))
                {
                   var eventHandler = EventHandler.CreateDelegate(typeof(EventHandler), this, method);
                   matchingEvent.AddEventHandler(view, eventHandler);
                }
                if (matchingEvent.EventHandlerType == typeof(FormClosedEventHandler))
                {
                    var eventHandler = FormClosedEventHandler.CreateDelegate(typeof(FormClosedEventHandler), this, method);
                    matchingEvent.AddEventHandler(view, eventHandler);
                }
            }
        }
    }
