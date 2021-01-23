    namespace CardManagment.Infrastructure.Events
    {
        using Microsoft.Practices.Prism.Events;
        /// <summary>
        /// Event to pass 'Selected Project' in between pages
        /// </summary>
        public class SelectedProjectViewEvent : CompositePresentationEvent<SelectedProjectViewEvent>
        {
            public object SelectedPorject { get; set; }
        }
    }
