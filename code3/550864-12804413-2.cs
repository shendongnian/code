          public int SelectedBaudRateItem
            {
                get { return _selectedBaudRate; }
                set
                {
                    _selectedBaudRate = value;                   
                    WriteMcomCommand(_selectedBaudRate );
                    ReadBusAndBaudRate();
                    NotifyPropertyChanged("SelectedBaudRateItem");
                }
            }    
            private void WriteMcomCommand(int id)
            {
            int speed = mI2c._busRate[id]; //mI2C is object of viewmodel class
    
            sendBuf[0] = Convert.ToByte((speed & 0xFF000000) >> 24);
            sendBuf[1] = Convert.ToByte((speed & 0x00FF0000) >> 16);
            sendBuf[2] = Convert.ToByte((speed & 0x0000FF00) >> 8);
            sendBuf[3] = Convert.ToByte(speed & 0x000000FF);
    
            cmd = (256 << 8 | 0x00);
            mCom.WriteInternalCommand(cmd, 4, ref sendBuf);
            }
