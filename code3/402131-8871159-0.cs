        private void TransitionEffectStarting(UserControl userControl)
        {
            CurrentUserControl = userControl;
            TransitionEffect[] effectGroup = Global.TransitionEffects[Random.Next(Global.TransitionEffects.Length)];
            TransitionEffect effect = effectGroup[Random.Next(effectGroup.Length)];
            RandomizedTransitionEffect randomEffect = effect as RandomizedTransitionEffect;
            if (randomEffect != null)
                randomEffect.RandomSeed = Random.NextDouble();
            DoubleAnimation animation = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(1.0)), FillBehavior.HoldEnd);
            animation.AccelerationRatio = 0.5;
            animation.DecelerationRatio = 0.5;
            animation.Completed += TransitionEffectCompleted;
            if (CurrentUserControl != null)
            {
                CurrentUserControl.Visibility = Visibility.Visible;
                Panel.SetZIndex(CurrentUserControl, 1);
            }
            if (PreviousUserControl != null)
            {
                PreviousUserControl.Visibility = Visibility.Visible;
                Panel.SetZIndex(PreviousUserControl, 0);
            }
            else
                Visibility = Visibility.Visible;
            effect.BeginAnimation(TransitionEffect.ProgressProperty, animation);
            if (PreviousUserControl != null)
            {
                VisualBrush visualBrush = new VisualBrush(PreviousUserControl);
                visualBrush.Viewbox = new Rect(0, 0, PreviousUserControl.ActualWidth, PreviousUserControl.ActualHeight);
                visualBrush.ViewboxUnits = BrushMappingMode.Absolute;
                effect.OldImage = visualBrush;
            }
            if (CurrentUserControl != null)
                CurrentUserControl.Effect = effect;
        }
        private void TransitionEffectCompleted(object sender, EventArgs e)
        {
            if (CurrentUserControl != null)
            {
                Panel.SetZIndex(CurrentUserControl, 0);
                CurrentUserControl.Effect = null;
                if (PreviousUserControl != null)
                    PreviousUserControl.Visibility = Visibility.Hidden;
            }
            PreviousUserControl = CurrentUserControl;
        }
