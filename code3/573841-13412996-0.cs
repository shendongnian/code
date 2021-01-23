         Button btn = new Button();
            btn.Transitions = new Windows.UI.Xaml.Media.Animation.TransitionCollection();
            Grid.SetRow(btn, j);
            Grid.SetColumn(btn, i);
            btn.Transitions.Add(new Windows.UI.Xaml.Media.Animation.RepositionThemeTransition());                    
            myGrig.Children.Add(btn);
