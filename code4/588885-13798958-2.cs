     public class TextBoxHelper : DependencyObject
        {
            public class MvvmCommand : DependencyObject, ICommand
            {
                readonly Action<object> _execute;
                readonly Func<object, bool> _canExecute;
                public event EventHandler CanExecuteChanged;
                public MvvmCommand(Action<object> execute, Func<object, bool> canExecute = null)
                {
                    if (execute == null) throw new ArgumentNullException("command");
                    _canExecute = canExecute == null ? parmeter => MvvmCommand.AlwaysCanExecute() : canExecute;
                    _execute = execute;
                }
                public object Tag
                {
                    get { return (object)GetValue(TagProperty); }
                    set { SetValue(TagProperty, value); }
                }
                public static readonly DependencyProperty TagProperty = DependencyProperty.Register("Tag", typeof(object), typeof(MvvmCommand), new PropertyMetadata(null));
                static bool AlwaysCanExecute()
                {
                    return true;
                }
                public void EvaluateCanExecute()
                {
                    EventHandler temp = CanExecuteChanged;
                    if (temp != null)
                        temp(this, EventArgs.Empty);
                }
                public virtual void Execute(object parameter)
                {
                    _execute(parameter == null ? this : parameter);
                }
                public virtual bool CanExecute(object parameter)
                {
                    return _canExecute == null ? true : _canExecute(parameter);
                }
            }
    
            public static Key GetFocusKey(DependencyObject obj)
            {
                return (Key)obj.GetValue(FocusKeyProperty);
            }
    
            public static void SetFocusKey(DependencyObject obj, Key value)
            {
                obj.SetValue(FocusKeyProperty, value);
            }
    
            public static readonly DependencyProperty FocusKeyProperty =
                DependencyProperty.RegisterAttached("FocusKey", typeof(Key), typeof(TextBoxHelper), new PropertyMetadata(Key.None, new PropertyChangedCallback((s, e) =>
                    {
                        UIElement targetElement = s as UIElement;
                        if (targetElement != null)
                        {
                            MvvmCommand command = new MvvmCommand(parameter => TextBoxHelper.FocusCommand(parameter))
                                {
                                    Tag = targetElement, 
                                };
                            InputGesture inputg = new KeyGesture((Key)e.NewValue);
                            (Window.GetWindow(targetElement)).InputBindings.Add(new InputBinding(command, inputg));
                        }
                    })));
    
            public static void FocusCommand(object parameter)
            {
                MvvmCommand targetCommand = parameter as MvvmCommand;
                if (targetCommand != null)
                {
                    UIElement targetElement = targetCommand.Tag as UIElement;
                    if (targetElement != null)
                    {
                        targetElement.Focus();
                    }
                }
            }
        }
