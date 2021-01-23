    using Microsoft.Xaml.Interactivity;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    public class SynchronizeHorizontalOffsetBehavior : Behavior<ScrollViewer>
    {
        public static ScrollViewer GetSource(DependencyObject obj)
        {
            return (ScrollViewer)obj.GetValue(SourceProperty);
        }
        public static void SetSource(DependencyObject obj, ScrollViewer value)
        {
            obj.SetValue(SourceProperty, value);
        }
        // Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.RegisterAttached("Source", typeof(object), typeof(SynchronizeHorizontalOffsetBehavior), new PropertyMetadata(null, SourceChangedCallBack));
        private static void SourceChangedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SynchronizeHorizontalOffsetBehavior synchronizeHorizontalOffsetBehavior = d as SynchronizeHorizontalOffsetBehavior;
            if (synchronizeHorizontalOffsetBehavior != null)
            {
                var oldSourceScrollViewer = e.OldValue as ScrollViewer;
                var newSourceScrollViewer = e.NewValue as ScrollViewer;
                if (oldSourceScrollViewer != null)
                {
                    oldSourceScrollViewer.ViewChanged -= synchronizeHorizontalOffsetBehavior.SourceScrollViewer_ViewChanged;
                }
                if (newSourceScrollViewer != null)
                {
                    newSourceScrollViewer.ViewChanged += synchronizeHorizontalOffsetBehavior.SourceScrollViewer_ViewChanged;
                    synchronizeHorizontalOffsetBehavior.UpdateTargetViewAccordingToSource(newSourceScrollViewer);
                }
            }
        }
        private void SourceScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            ScrollViewer sourceScrollViewer = sender as ScrollViewer;
            this.UpdateTargetViewAccordingToSource(sourceScrollViewer);
        }
        private void UpdateTargetViewAccordingToSource(ScrollViewer sourceScrollViewer)
        {
            if (sourceScrollViewer != null)
            {
                if (this.AssociatedObject != null)
                {
                    this.AssociatedObject.ChangeView(sourceScrollViewer.HorizontalOffset, null, null);
                }
            }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            var source = GetSource(this.AssociatedObject);
            this.UpdateTargetViewAccordingToSource(source);
        }
    }
