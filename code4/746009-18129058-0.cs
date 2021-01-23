    public static class NamedStoryboard
    {
        public static readonly DependencyProperty StoryboardProperty = DependencyProperty.RegisterAttached(
          "Storyboard",
          typeof(Storyboard),
          typeof(NamedStoryboard),
          new FrameworkPropertyMetadata(DoAttach));
        [AttachedPropertyBrowsableForType(typeof(BeginStoryboard))]
        public static Storyboard GetStoryboard(BeginStoryboard obj)
        {
            return (Storyboard)obj.GetValue(StoryboardProperty);
        }
        public static void SetStoryboard(BeginStoryboard obj, Storyboard value)
        {
            obj.SetValue(StoryboardProperty, value);
        }
        public static readonly DependencyProperty TargetNameProperty = DependencyProperty.RegisterAttached(
          "TargetName",
          typeof(string),
          typeof(NamedStoryboard),
          new FrameworkPropertyMetadata(DoAttach));
        [AttachedPropertyBrowsableForType(typeof(BeginStoryboard))]
        public static string GetTargetName(BeginStoryboard obj)
        {
            return (string)obj.GetValue(TargetNameProperty);
        }
        public static void SetTargetName(BeginStoryboard obj, string value)
        {
            obj.SetValue(TargetNameProperty, value);
        } 
        private static void DoAttach(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var begin = d as BeginStoryboard;
            if (begin == null) return;
            var sb = GetStoryboard(begin);
            if (sb == null) return;
            var name = GetTargetName(begin);
            if (string.IsNullOrEmpty(name))
                begin.Storyboard = sb;
            else
            {
                var clone = sb.Clone();
                Storyboard.SetTargetName(clone, name);
                begin.Storyboard = clone;
            }
        }
    }
