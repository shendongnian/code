    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
     
    public class Flipper
    {
        public enum Directions { LeftToRight, RightToLeft }
     
        public static void FlipItem(UIElement over, UIElement under, Directions direction = Directions.LeftToRight, int duration = 200)
        {
            // setup visible plane
            over.Visibility = Visibility.Visible;
            over.Projection = new PlaneProjection { CenterOfRotationY = 0 };
     
            // setup hidden plane
            under.Visibility = Visibility.Collapsed;
            under.Projection = new PlaneProjection { CenterOfRotationY = 0 };
     
            // gen storyboard
            var _StoryBoard = new System.Windows.Media.Animation.Storyboard();
            var _Duration = TimeSpan.FromMilliseconds(duration);
     
            // add animation: hide-n-show items
            _StoryBoard.Children.Add(CreateVisibility(_Duration, over, false));
            _StoryBoard.Children.Add(CreateVisibility(_Duration, under, true));
     
            // add animation: rotate items
            if (direction == Directions.LeftToRight)
            {
                _StoryBoard.Children.Add(CreateRotation(_Duration, 0, -90, -180, (PlaneProjection)over.Projection));
                _StoryBoard.Children.Add(CreateRotation(_Duration, 180, 90, 0, (PlaneProjection)under.Projection));
            }
            else if (direction == Directions.RightToLeft)
            {
                _StoryBoard.Children.Add(CreateRotation(_Duration, 0, 90, 180, (PlaneProjection)over.Projection));
                _StoryBoard.Children.Add(CreateRotation(_Duration, -180, -90, 0, (PlaneProjection)under.Projection));
            }
     
            // start animation
            _StoryBoard.Begin();
        }
     
        private static DoubleAnimationUsingKeyFrames CreateRotation(TimeSpan duration, double degreesFrom, double degreesMid, double degreesTo, PlaneProjection projection)
        {
            var _One = new EasingDoubleKeyFrame { KeyTime = new TimeSpan(0), Value = degreesFrom, EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseIn } };
            var _Two = new EasingDoubleKeyFrame { KeyTime = new TimeSpan(duration.Ticks / 2), Value = degreesMid, EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseIn } };
            var _Three = new EasingDoubleKeyFrame { KeyTime = new TimeSpan(duration.Ticks), Value = degreesTo, EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut } };
     
            var _Animation = new DoubleAnimationUsingKeyFrames { BeginTime = new TimeSpan(0) };
            _Animation.KeyFrames.Add(_One);
            _Animation.KeyFrames.Add(_Two);
            _Animation.KeyFrames.Add(_Three);
            Storyboard.SetTargetProperty(_Animation, new PropertyPath("RotationY"));
            Storyboard.SetTarget(_Animation, projection);
            return _Animation;
        }
     
        private static ObjectAnimationUsingKeyFrames CreateVisibility(Duration duration, UIElement element, bool show)
        {
            var _One = new DiscreteObjectKeyFrame { KeyTime = new TimeSpan(0), Value = (show ? Visibility.Collapsed : Visibility.Visible) };
            var _Two = new DiscreteObjectKeyFrame { KeyTime = new TimeSpan(duration.TimeSpan.Ticks / 2), Value = (show ? Visibility.Visible : Visibility.Collapsed) };
     
            var _Animation = new ObjectAnimationUsingKeyFrames { BeginTime = new TimeSpan(0) };
            _Animation.KeyFrames.Add(_One);
            _Animation.KeyFrames.Add(_Two);
            Storyboard.SetTargetProperty(_Animation, new PropertyPath("Visibility"));
            Storyboard.SetTarget(_Animation, element);
            return _Animation;
        }
    }
