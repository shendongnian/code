    if ((wireObject1._connectionstart[i] == cyclicSelectedIndex[0] && wireObject1._connectionend[i] == cyclicSelectedIndex[1]) ||
                                           (wireObject1._connectionstart[i] == cyclicSelectedIndex[1] && wireObject1._connectionend[i] == cyclicSelectedIndex[0]))
                                        {
                                            button2.Enabled = false;
                                            button4.Enabled = true;
                                            break;
                                        }
                                        else
                                        {
                                            button4.Enabled = false;
                                        }
