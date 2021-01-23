        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ...
            transitions = new TransitionCollection();
            foreach (Transition transition in dataListView.ItemContainerTransitions)
            {
                transitions.Add(transition);
            }
            ...
        }
