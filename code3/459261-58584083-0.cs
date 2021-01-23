        private IKeyboardMouseEvents _globalHook;
        private void Subscribe()
        {
            if (_globalHook == null)
            {
                // Note: for the application hook, use the Hook.AppEvents() instead
                _globalHook = Hook.GlobalEvents();
                _globalHook.KeyPress += GlobalHookKeyPress;
            }
        }
        private static void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("KeyPress: \t{0}", e.KeyChar);
        }
        private void Unsubscribe()
        {
            if (_globalHook != null)
            {
                _globalHook.KeyPress -= GlobalHookKeyPress;
                _globalHook.Dispose();
            }
        }
