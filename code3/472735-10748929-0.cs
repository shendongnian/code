     Dispatcher.Invoke(DispatcherPriority.Normal,
                        new Action(
                            delegate()
                            {
                                //access control created by main thread  
                                textBlock.Text = msg;
                            }
                            ));
