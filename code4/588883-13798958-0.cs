      public class TextBoxHelper : DependencyObject
        {
            public class MvvmCommand : DependencyObject, ICommand
            {
                // Command instances.
                readonly Action<object> _execute;
                readonly Func<object, bool> _canExecute;
    
                #region Public Events
                /// <summary>
                /// Occurs when changes occur that affect whether or not the command should execute.
                /// </summary>
                public event EventHandler CanExecuteChanged;
                #endregion
                #region Construction
                /// <summary>
                /// Initializes a new instance of the <see cref="MvvmCommand"/> class.
                /// </summary>
                /// <param name="execute">A reference to the execute method.</param>
                /// <param name="canExecute">A reference to the function that will evaluate if this command can be executed or not.</param>
                /// <remarks>
                ///     If canExecute is set to null then a static function will be used that always returns true.
                /// </remarks>
                public MvvmCommand(Action<object> execute, Func<object, bool> canExecute = null)
                {
                    // Quick parameter check, we need the command at least.
                    if (execute == null) throw new ArgumentNullException("command");
    
                    // Hook up the instances.
                    _canExecute = canExecute == null ? parmeter => MvvmCommand.AlwaysCanExecute() : canExecute;
                    _execute = execute;
                }
                #endregion
    
                /// <summary>
                /// Gets or sets a tag that's been attached to the command.
                /// </summary>
                public object Tag
                {
                    get { return (object)GetValue(TagProperty); }
                    set { SetValue(TagProperty, value); }
                }
    
                /// <summary>
                /// Dependency backing property for the <see cref="Tag"/> property.
                /// </summary>
                public static readonly DependencyProperty TagProperty = DependencyProperty.Register("Tag", typeof(object), typeof(MvvmCommand), new PropertyMetadata(null));
    
                /// <summary>
                /// A method that returns true, this is used when no CanExecute parameter is given.
                /// </summary>
                /// <returns><c>true</c></returns>
                static bool AlwaysCanExecute()
                {
                    return true;
                }
    
                /// <summary>
                /// Calls the <see cref="CanExecuteChanged"/> event.
                /// </summary>
                public void EvaluateCanExecute()
                {
                    // Raise the can execute event.
                    EventHandler temp = CanExecuteChanged;
                    if (temp != null)
                        temp(this, EventArgs.Empty);
                }
    
                /// <summary>
                /// Defines the method to be called when the command is invoked.
                /// </summary>
                /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
                public virtual void Execute(object parameter)
                {
                    // Call the command delegate.
                    _execute(parameter == null ? this : parameter);
                }
    
                /// <summary>
                /// Defines the method that determines whether the command can execute in its current state.
                /// </summary>
                /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
                /// <returns>
                /// true if this command can be executed; otherwise, false.
                /// </returns>
                public virtual bool CanExecute(object parameter)
                {
                    // If there is a null for the delegate then we return true, if not we call the delegate 
                    // and return it's value.
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
    
            // Using a DependencyProperty as the backing store for FocusKey.  This enables animation, styling, binding, etc...
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
