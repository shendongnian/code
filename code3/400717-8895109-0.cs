                                             try
                                             {
                                                 action();
                                             }
                                             catch (Exception ex)
                                             {
                                                 OnException(ex);
                                             }
                                         });
