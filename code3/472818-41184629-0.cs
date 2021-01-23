    // Decompiled with JetBrains decompiler
    // Type: System.Progress`1
    // Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
    // MVID: 85AB3664-E4CA-41A0-86E3-96342ED95AAA
    // Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll
    
    using System.Threading;
    
    namespace System
    {
      /// <summary>Provides an <see cref="T:System.IProgress`1" /> that invokes callbacks for each reported progress value.</summary>
      /// <typeparam name="T">Specifies the type of the progress report value.</typeparam>
      [__DynamicallyInvokable]
      public class Progress<T> : IProgress<T>
      {
        private readonly SynchronizationContext m_synchronizationContext;
        private readonly Action<T> m_handler;
        private readonly SendOrPostCallback m_invokeHandlers;
    
        /// <summary>Raised for each reported progress value.</summary>
        [__DynamicallyInvokable]
        public event EventHandler<T> ProgressChanged;
    
        /// <summary>Initializes the <see cref="T:System.Progress`1" /> object.</summary>
        [__DynamicallyInvokable]
        public Progress()
        {
          this.m_synchronizationContext = SynchronizationContext.CurrentNoFlow ?? ProgressStatics.DefaultContext;
          this.m_invokeHandlers = new SendOrPostCallback(this.InvokeHandlers);
        }
    
        /// <summary>Initializes the <see cref="T:System.Progress`1" /> object with the specified callback.</summary>
        /// <param name="handler">A handler to invoke for each reported progress value. This handler will be invoked in addition to any delegates registered with the <see cref="E:System.Progress`1.ProgressChanged" /> event. Depending on the <see cref="T:System.Threading.SynchronizationContext" /> instance captured by the <see cref="T:System.Progress`1" /> at construction, it is possible that this handler instance could be invoked concurrently with itself.</param>
        [__DynamicallyInvokable]
        public Progress(Action<T> handler)
          : this()
        {
          if (handler == null)
            throw new ArgumentNullException("handler");
          this.m_handler = handler;
        }
    
        /// <summary>Reports a progress change.</summary>
        /// <param name="value">The value of the updated progress.</param>
        [__DynamicallyInvokable]
        protected virtual void OnReport(T value)
        {
          // ISSUE: reference to a compiler-generated field
          if (this.m_handler == null && this.ProgressChanged == null)
            return;
          this.m_synchronizationContext.Post(this.m_invokeHandlers, (object) value);
        }
    
        [__DynamicallyInvokable]
        void IProgress<T>.Report(T value)
        {
          this.OnReport(value);
        }
    
        private void InvokeHandlers(object state)
        {
          T e = (T) state;
          Action<T> handler = this.m_handler;
          // ISSUE: reference to a compiler-generated field
          EventHandler<T> progressChanged = this.ProgressChanged;
          if (handler != null)
            handler(e);
          if (progressChanged == null)
            return;
          progressChanged((object) this, e);
        }
      }
    }
