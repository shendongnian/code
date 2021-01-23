    Application.Current.Dispatcher.BeginInvoke(
                        DispatcherPriority.Normal,
                        new Action(
                            delegate()
                            {
                                Console.WriteLine("Inside invoke?!");
                            }
                        )
                    );
