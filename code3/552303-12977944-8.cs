    namespace TriggerTest
    {
        using System.Windows.Interactivity;
        /// <summary>
        /// Allows a trigger action to be invoked from code.
        /// </summary>
        public static class TriggerActionExtensions
        {
            /// <summary>
            /// Invokes a <see cref="TriggerAction"/> with the specified parameter.
            /// </summary>
            /// <param name="action">The <see cref="TriggerAction"/>.</param>
            /// <param name="parameter">The parameter value.</param>
            public static void Invoke(this TriggerAction action, object parameter)
            {
                ManualTrigger trigger = new ManualTrigger();
                trigger.Actions.Add(action);
                try
                {
                    trigger.Invoke(parameter);
                }
                finally
                {
                    trigger.Actions.Remove(action);
                }
            }
            /// <summary>
            /// Invokes a <see cref="TriggerAction"/>.
            /// </summary>
            /// <param name="action">The <see cref="TriggerAction"/>.</param>
            public static void Invoke(this TriggerAction action)
            {
                action.Invoke(null);
            }
        }
    }
