    Dispatcher.CurrentDispatcher.Invoke(
                        DispatcherPriority.Normal,
                        new Action(
                            delegate()
                            {
                                Console.WriteLine("Inside invoke?!");
                            }
                        )
                    );
