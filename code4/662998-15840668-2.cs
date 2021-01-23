    using System.Reflection;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    
    namespace Flexman
    {
        public class TextBoxUpdateSourceBehaviour
        {
            private static PropertyInfo _boundProperty;
    
            public static readonly DependencyProperty BindingSourceProperty =
                DependencyProperty.RegisterAttached(
                "BindingSource", 
                typeof(string), 
                typeof(TextBoxUpdateSourceBehaviour),
                new PropertyMetadata(default(string), OnBindingChanged));
    
            public static void SetBindingSource(TextBox element, string value)
            {
                element.SetValue(BindingSourceProperty, value);
            }
    
            public static string GetBindingSource(TextBox element)
            {
                return (string)element.GetValue(BindingSourceProperty);
            }
    
            private static void OnBindingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var txt = d as TextBox;
                if (txt == null)
                    return;
    
                txt.Loaded += OnLoaded;
                txt.TextChanged += OnTextChanged;
            }
    
            static void OnLoaded(object sender, RoutedEventArgs e)
            {
                var txt = sender as TextBox;
                if (txt == null)
                    return;
    
                // Reflect the datacontext of the textbox to find the field to bind to.
                var dataContextType = txt.DataContext.GetType();
                _boundProperty = dataContextType.GetRuntimeProperty(GetBindingSource(txt));
    
                // If you want the behaviour to handle your binding as well, uncomment the following.
                //var binding = new Binding();
                //binding.Mode = BindingMode.TwoWay;
                //binding.Path = new PropertyPath(GetBindingSource(txt));
                //binding.Source = txt.DataContext;
                //BindingOperations.SetBinding(txt, TextBox.TextProperty, binding);
            }
    
            static void OnTextChanged(object sender, TextChangedEventArgs e)
            {
                var txt = sender as TextBox;
                if (txt == null)
                    return;
    
                if (_boundProperty.GetValue(txt.DataContext).Equals(txt.Text)) return;
                _boundProperty.SetValue(txt.DataContext, txt.Text);
            }
        }
    }
