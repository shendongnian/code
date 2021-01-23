     public void ReadIndefinitely(string tiffFileFolder, List<string> channelName, int signalLength)
            {            
                string tiffFileName; 
                int nActiveStats = _signalDisplay.NActiveStatsOneChannel;
                int nActiveChannels = _signalDisplay.NActiveChannel;
                double signal;
                double DeltaT;
                bool keepReading = true;
                int channelIndex;
                int statIndex;
                int signalIndex = 0;
    
                while (signalIndex < signalLength)
                {                
                    for (int i = 0; i < nActiveChannels; i++)
                    {
                        tiffFileName = tiffFileFolder + channelName[i] + "_0001_0001_0001_" + (signalIndex + 1).ToString("0000") + ".tif";
                        channelIndex = (int)Enum.Parse(typeof(ChannelList), channelName[i]);
                        keepReading = true;
                        if(keepReading)
                        {
                            if (File.Exists(tiffFileName))
                            {
                                if (!IsFileLocked(tiffFileName))
                                {
                                    for (int j = 0; j < nActiveStats; j++)
                                    {
                                        statIndex = _statsEnableEnumIndex[j];
                                        DeltaT = ExtractTiffDeltaT(tiffFileName, "DeltaT=", 1);
                                        signal = _signalManager.GetSignal(statIndex, tiffFileName);
                                        UpdateSignal(channelIndex, j, signalIndex, DeltaT, signal);
                                    }
    
                                    keepReading = false;
                                    signalIndex++;      
                                }
                                else
                                {
                                    System.Threading.Thread.Sleep(30);
                                }
                            }
                        }
    
                       // if (signalIndex % 5 == 0)
                        _signalDisplay.SetData(_XList, _YList, true);
                    }
    
                            
                }
            }
                  
