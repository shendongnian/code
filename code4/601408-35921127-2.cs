    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    
    public static class Blink
    {
        public static readonly DependencyProperty WhenProperty = DependencyProperty.RegisterAttached(
            "When",
            typeof(bool?),
            typeof(Blink),
            new PropertyMetadata(false, OnWhenChanged));
    
        public static readonly DependencyProperty FromProperty = DependencyProperty.RegisterAttached(
            "From",
            typeof(Color),
            typeof(Blink),
            new FrameworkPropertyMetadata(Colors.Transparent, FrameworkPropertyMetadataOptions.Inherits));
    
        public static readonly DependencyProperty ToProperty = DependencyProperty.RegisterAttached(
            "To",
            typeof(Color),
            typeof(Blink),
            new FrameworkPropertyMetadata(Colors.Orange, FrameworkPropertyMetadataOptions.Inherits));
    
        public static readonly DependencyProperty PropertyProperty = DependencyProperty.RegisterAttached(
            "Property",
            typeof(DependencyProperty),
            typeof(Blink),
            new PropertyMetadata(default(DependencyProperty)));
    
        public static readonly DependencyProperty DurationProperty = DependencyProperty.RegisterAttached(
            "Duration",
            typeof(Duration),
            typeof(Blink),
            new PropertyMetadata(new Duration(TimeSpan.FromSeconds(1))));
    
        public static readonly DependencyProperty AutoReverseProperty = DependencyProperty.RegisterAttached(
            "AutoReverse",
            typeof(bool),
            typeof(Blink),
            new PropertyMetadata(true));
    
        public static readonly DependencyProperty RepeatBehaviorProperty = DependencyProperty.RegisterAttached(
            "RepeatBehavior",
            typeof(RepeatBehavior),
            typeof(Blink),
            new PropertyMetadata(RepeatBehavior.Forever));
    
        private static readonly DependencyProperty OldBrushProperty = DependencyProperty.RegisterAttached(
            "OldBrush",
            typeof(Brush),
            typeof(Blink),
            new PropertyMetadata(null));
    
        public static void SetWhen(this UIElement element, bool? value)
        {
            element.SetValue(WhenProperty, value);
        }
    
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static bool? GetWhen(this UIElement element)
        {
            return (bool?)element.GetValue(WhenProperty);
        }
    
        public static void SetFrom(this DependencyObject element, Color value)
        {
            element.SetValue(FromProperty, value);
        }
    
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Color GetFrom(this DependencyObject element)
        {
            return (Color)element.GetValue(FromProperty);
        }
    
        public static void SetTo(this DependencyObject element, Color value)
        {
            element.SetValue(ToProperty, value);
        }
    
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Color GetTo(this DependencyObject element)
        {
            return (Color)element.GetValue(ToProperty);
        }
    
        public static void SetProperty(this UIElement element, DependencyProperty value)
        {
            element.SetValue(PropertyProperty, value);
        }
    
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static DependencyProperty GetProperty(this UIElement element)
        {
            return (DependencyProperty)element.GetValue(PropertyProperty);
        }
    
        public static void SetDuration(this UIElement element, Duration value)
        {
            element.SetValue(DurationProperty, value);
        }
    
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Duration GetDuration(this UIElement element)
        {
            return (Duration)element.GetValue(DurationProperty);
        }
    
        public static void SetAutoReverse(this UIElement element, bool value)
        {
            element.SetValue(AutoReverseProperty, value);
        }
    
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static bool GetAutoReverse(this UIElement element)
        {
            return (bool)element.GetValue(AutoReverseProperty);
        }
    
        public static void SetRepeatBehavior(this UIElement element, RepeatBehavior value)
        {
            element.SetValue(RepeatBehaviorProperty, value);
        }
    
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static RepeatBehavior GetRepeatBehavior(this UIElement element)
        {
            return (RepeatBehavior)element.GetValue(RepeatBehaviorProperty);
        }
    
        private static void OnWhenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var property = GetProperty((UIElement)d) ?? GetDefaultProperty(d);
            if (property == null || !typeof(Brush).IsAssignableFrom(property.PropertyType))
            {
                if (DesignerProperties.GetIsInDesignMode(d))
                {
                    if (property != null)
                    {
                        throw new ArgumentException($"Could not blink for {d.GetType().Name}.{property.Name}", nameof(d));
                    }
                }
    
                return;
            }
    
            AnimateBlink(e.NewValue as bool?, (UIElement)d, property);
        }
    
        private static DependencyProperty GetDefaultProperty(DependencyObject d)
        {
            if (d is Control)
            {
                return Control.BackgroundProperty;
            }
    
            if (d is Panel)
            {
                return Panel.BackgroundProperty;
            }
    
            if (d is Border)
            {
                return Border.BackgroundProperty;
            }
    
            if (d is Shape)
            {
                return Shape.FillProperty;
            }
    
            if (DesignerProperties.GetIsInDesignMode(d))
            {
                throw new ArgumentException($"Could not find property to blink for {d.GetType().Name}", nameof(d));
            }
    
            return null;
        }
    
        private static void AnimateBlink(bool? blink, UIElement element, DependencyProperty property)
        {
            if (element == null)
            {
                return;
            }
            if (blink == true)
            {
                var brush = element.GetValue(property);
                element.SetCurrentValue(OldBrushProperty, brush);
                element.SetValue(property, Brushes.Transparent);
                var from = element.GetFrom();
                var to = element.GetTo();
                var sb = new Storyboard();
                var duration = element.GetDuration();
                var animation = new ColorAnimation(from, to, duration)
                {
                    AutoReverse = element.GetAutoReverse(),
                    RepeatBehavior = element.GetRepeatBehavior()
                };
                Storyboard.SetTarget(animation, element);
                Storyboard.SetTargetProperty(animation, new PropertyPath($"{property.Name}.(SolidColorBrush.Color)"));
                sb.Children.Add(animation);
                sb.Begin();
            }
            else
            {
                var brush = element.GetValue(OldBrushProperty);
                element.BeginAnimation(property, null);
                element.SetCurrentValue(property, brush);
            }
        }
    }
<!-- -->
