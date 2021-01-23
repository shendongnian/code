    namespace TriggerTest
    {
        using System.Windows;
        /// <summary>
        /// A trigger that may be invoked from code.
        /// </summary>
        public class ManualTrigger : System.Windows.Interactivity.TriggerBase<DependencyObject>
        {
            /// <summary>
            /// Invokes the trigger's actions.
            /// </summary>
            /// <param name="parameter">The parameter value.</param>
            public void Invoke(object parameter)
            {
                this.InvokeActions(parameter);
            }
        }
    }
