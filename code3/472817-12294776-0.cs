    using System;
    using System.Runtime;
    using System.Threading;
    namespace System
    {
        [__DynamicallyInvokable]
        public class Progress<T> : IProgress<T>
        {
            private readonly SynchronizationContext m_synchronizationContext;
            private readonly Action<T> m_handler;
            private readonly SendOrPostCallback m_invokeHandlers;
            [__DynamicallyInvokable]
            public event EventHandler<T> ProgressChanged
            {
                [__DynamicallyInvokable]
                add
                {
                    EventHandler<T> eventHandler = this.ProgressChanged;
                    EventHandler<T> eventHandler2;
                    do
                    {
                        eventHandler2 = eventHandler;
                        EventHandler<T> value2 = (EventHandler<T>)Delegate.Combine(eventHandler2, value);
                        eventHandler = Interlocked.CompareExchange<EventHandler<T>>(ref this.ProgressChanged, value2, eventHandler2);
                    }
                    while (eventHandler != eventHandler2);
                }
                [__DynamicallyInvokable]
                remove
                {
                    EventHandler<T> eventHandler = this.ProgressChanged;
                    EventHandler<T> eventHandler2;
                    do
                    {
                        eventHandler2 = eventHandler;
                        EventHandler<T> value2 = (EventHandler<T>)Delegate.Remove(eventHandler2, value);
                        eventHandler = Interlocked.CompareExchange<EventHandler<T>>(ref this.ProgressChanged, value2, eventHandler2);
                    }
                    while (eventHandler != eventHandler2);
                }
            }
            [__DynamicallyInvokable]
            public Progress()
            {
                this.m_synchronizationContext = (SynchronizationContext.CurrentNoFlow ?? ProgressStatics.DefaultContext);
                this.m_invokeHandlers = new SendOrPostCallback(this.InvokeHandlers);
            }
            [__DynamicallyInvokable]
            public Progress(Action<T> handler) : this()
            {
                if (handler == null)
                {
                    throw new ArgumentNullException("handler");
                }
                this.m_handler = handler;
            }
            [__DynamicallyInvokable]
            protected virtual void OnReport(T value)
            {
                Action<T> handler = this.m_handler;
                EventHandler<T> progressChanged = this.ProgressChanged;
                if (handler != null || progressChanged != null)
                {
                    this.m_synchronizationContext.Post(this.m_invokeHandlers, value);
                }
            }
            [__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            void IProgress<T>.Report(T value)
            {
                this.OnReport(value);
            }
            private void InvokeHandlers(object state)
            {
                T t = (T)((object)state);
                Action<T> handler = this.m_handler;
                EventHandler<T> progressChanged = this.ProgressChanged;
                if (handler != null)
                {
                    handler(t);
                }
                if (progressChanged != null)
                {
                    progressChanged(this, t);
                }
            }
        }
    }
