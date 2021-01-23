    // find an item
    var itemOne = collection.Where(i =>
                                        {
                                            try
                                            {
                                                if (i.column1 == "1")
                                                {
                                                    return true;
                                                }
                                            }
                                            catch
                                            {
                                                // ignore error, column doesn't exist
                                            }
                                            return false;
                                        });
