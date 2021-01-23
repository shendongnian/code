    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Interactivity;
    using System;
    
    namespace Misc
    {
       public class CommandWithEventAction : TriggerAction<UIElement>
       {
          public event Func<object, object> Execute;
    
          public static DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(CommandWithEventAction), null);
          public ICommand Command
          {
             get
             {
                return (ICommand)GetValue(CommandProperty);
             }
             set
             {
                SetValue(CommandProperty, value);
             }
          }
    
    
          public static DependencyProperty ParameterProperty = DependencyProperty.Register("Parameter", typeof(object), typeof(CommandWithEventAction), null);
          public object Parameter
          {
             get
             {
                return GetValue(ParameterProperty);
             }
             set
             {
                SetValue(ParameterProperty, value);
    
             }
          }
    
          protected override void Invoke(object parameter)
          {
             var result = Execute(Parameter);
             Command.Execute(result);
          }
    
       }
    }
