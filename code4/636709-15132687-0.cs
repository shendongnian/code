    _dataSet.Messages.RowChanged += delegate
                                    {
                                        MessageDataGridView.Invalidate();
                                        MessageDataGridView.Update();
                                    };
