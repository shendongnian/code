        private void AddTransitions()
        {
            // Only add the transitions if you need to
            if (dataListView.ItemContainerTransitions.Count == 0)
            {
                foreach (Transition transition in this.transitions)
                {
                    dataListView.ItemContainerTransitions.Add(transition);
                }
            }
        }
