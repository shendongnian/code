    _pxlValAllChan[0, signalIndex] = pxlValue;
                                                    DateTime currentTime = DateTime.Now; //has to come from real file: Tiff
                                                    TimeSpan timeSpan = currentTime - _startTime;
    
                                                    _timeStampAllChan[0, signalIndex] = Convert.ToInt16(timeSpan.TotalSeconds);
    
    
                                                    _pxlValOneChan = new int[_signalLength]; // no need to new it every time
                                                    _timeStampOneChan = new int[_signalLength];
                                                    for (int i = 0; i <= signalIndex; i++)
                                                    {
                                                        _pxlValOneChan[i] = _pxlValAllChan[0, i];
                                                        //_timeStampOneChan[i] = _timeStampAllChan[0, i];
                                                        _timeStampOneChan[i] = i;
                                                    }
                                                   
                                                    _signalDisplay.SetData(_timeStampOneChan, _pxlValOneChan, 0, true);
