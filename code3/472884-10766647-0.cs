    class Publisher {
      #if PocketPC // MethodInvoker delegate is not declared in CF!
      public delegate void MethodInvoker(); 
      #endif
      private Form _parent;
      public Publisher(Form parent) {
        _parent = parent;
      }
      public event EventHandler OnEventHandler;
      private void OnEvent() {
        if (OnEventHandler != null) {
          MethodInvoker mi = delegate { OnEventHandler(this, EventArgs.Empty); };
          try {
            _parent.BeginInvoke(methInvoker);
          } catch (ObjectDisposedException) {
          } catch (NullReferenceException err) {
            LogError("OnEvent NullReference", err);
          } catch (InvalidOperationException err) {
            LogError("OnEvent InvalidOperation", err);
          }
        }
      }
    }
