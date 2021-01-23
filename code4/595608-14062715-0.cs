    protected void TextBox_ShowEndOfLine(object sender, TextChangedEventArgs e)
        {
            if (sender == null) return;
            var box = sender as TextBox;
            if (!box.IsFocused && box.IsVisible)
            {
                IInputElement oldFocus = FocusManager.GetFocusedElement(FocusManager.GetFocusScope(this));
                box.Focus();
                box.Select(box.Text.Length, 0);
                box.Focus();
                // We wait for keyboard focus and regular focus before returning focus to the button
                var thread = new Thread((ThreadStart)delegate
                                            {
                                                // wait till focused
                                                while (true)
                                                {
                                                    var focused = (bool)Dispatcher.Invoke(new Func<bool>(() => box.IsKeyboardFocusWithin && box.IsFocused && box.IsInputMethodEnabled), DispatcherPriority.Send);
                                                    if (!focused)
                                                        Thread.Sleep(1);
                                                    else
                                                        break;
                                                }
                                                // Focus the old element
                                                Dispatcher.Invoke(new Action(() => oldFocus.Focus()), DispatcherPriority.SystemIdle);
                                            });
                thread.Start();
            }
            else if (!box.IsVisible)
            {
                // If the textbox is not visible, the cursor will not be moved to the end. Wait till it's visible.
                var thread = new Thread((ThreadStart)delegate
                                            {
                                                while (true)
                                                {
                                                    Thread.Sleep(10);
                                                    if (box.IsVisible)
                                                    {
                                                        Dispatcher.Invoke(new Action(delegate
                                                                                         {
                                                                                             box.Focus();
                                                                                             box.Select(box.Text.Length, 0);
                                                                                             box.Focus();
                                                                                             
                                                                                         }), DispatcherPriority.ApplicationIdle);
                                                        return;
                                                    }
                                                }
                                            });
                thread.Start();
            }
        }
