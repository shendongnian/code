            foreach (var system in provider.Systems)
            {
                var stackpanel = new StackPanel { Orientation = Orientation.Horizontal };
                foreach (var fx in system.Fxes)
                {
                    stackpanel.Children.Add(TrunkControl());
                }
                panel1.Children.Add(stackpanel); 
            }
