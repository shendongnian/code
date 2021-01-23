    var task = Task.Factory.StartNew(() =>
                                         {
                                             pic.Image = Properties.Resources.NEXT;
                                         },
                                     CancellationToken.None,
                                     TaskCreationOptions.None,
                                     ui);
