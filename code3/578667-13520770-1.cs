    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Tridion.ContentManager;
    using Tridion.ContentManager.CommunicationManagement;
    using Tridion.ContentManager.ContentManagement;
    using Tridion.ContentManager.ContentManagement.Fields;
    using Tridion.ContentManager.Extensibility;
    using Tridion.ContentManager.Extensibility.Events;
    namespace NicksEventSystem
    {
        [TcmExtension("NicksEventSystemExtension")]
        public class NicksEventHandler : TcmExtension
        {
            public NicksEventHandler()
            {
                Subscribe();
            }
            private void Subscribe()
            {
                EventSystem.Subscribe<Component, FinishActivityEventArgs>(MyEvent, EventPhases.TransactionCommitted);
            }
            private void MyEvent(Component wfComponent)
            {
                //... Do stuff!
            }
        }
    }
