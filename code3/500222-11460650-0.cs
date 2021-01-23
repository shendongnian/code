         // This snippet is in the Form_Load event, and it initializes teh scanner
            InitializeScanner();
            ScannerPort.ReadExisting();
            System.Threading.Thread.Sleep(1000);
         // ens snippet from Form_Load.
            this.ScannerPort.DataReceived += new SerialDataReceivedEventHandler(ScannerPort_DataReceived);
    delegate void DoScanCallback();  // used for updating the form UI
    void DoScan()
        {
            if (this.txtCouponCount.InvokeRequired)
            {
                DoScanCallback d = new DoScanCallback(DoScan);
                this.Invoke(d);
                return;
            }
            System.Threading.Thread.Sleep(100);
            string ScanData = ScannerPort.ReadExisting();
            if (isInScanMode)
            {
                try
                {
                    HandleScanData(ScanData);
                }
                catch (Exception ex)
                {
						 System.Media.SystemSounds.Beep.Play();
						 MessageBox.Show("Invalid Scan");
                }
            }
        }
        void ScannerPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            // this call to sleep allows the scanner to receive the entire scan.
            // without this sleep, we've found that we get only a partial scan.
            try
            {
                DoScan();
            }
            catch (Exception ex)
            {
					System.Media.SystemSounds.Beep.Play();
					MessageBox.Show("Unable to handle scan event in ScannerPort_DataReceived." + System.Environment.NewLine + ex.ToString());
            }
        }
        void Port_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {
			  System.Media.SystemSounds.Beep.Play();
			  MessageBox.Show(e.EventType.ToString());
        }
        private void HandleScanData(string ScanData)
        {
            //MessageBox.Show(ScanData + System.Environment.NewLine + ScanData.Length.ToString());
            //Determine which type of barcode has been scanned, and handle appropriately.
            if (ScanData.StartsWith("A") && ScanData.Length == 14)
            {
                try
                {
                    ProcessUpcCoupon(ScanData);
                }
                catch (Exception ex)
                {
						 System.Media.SystemSounds.Beep.Play();
						 MessageBox.Show("Unable to process UPC coupon data" + System.Environment.NewLine + ex.ToString());
                }
            }
            else if (ScanData.StartsWith("8110"))
            {
                try
                {
                    ProcessDataBarCoupon(ScanData);
                }
                catch (Exception ex)
                {
						 System.Media.SystemSounds.Beep.Play();
						 MessageBox.Show("Unable to process DataBar coupon data" + System.Environment.NewLine + ex.ToString());
                }
            }
            else
            {
					System.Media.SystemSounds.Beep.Play();
					MessageBox.Show("Invalid Scan" + System.Environment.NewLine + ScanData);
            }
        }
        private void InitializeScanner()
        {
            try
            {
                ScannerPort.PortName = Properties.Settings.Default.ScannerPort;
                ScannerPort.ReadBufferSize = Properties.Settings.Default.ScannerReadBufferSize;
                ScannerPort.Open();
                ScannerPort.BaudRate = Properties.Settings.Default.ScannerBaudRate;
                ScannerPort.DataBits = Properties.Settings.Default.ScannerDataBit;
                ScannerPort.StopBits = Properties.Settings.Default.ScannerStopBit;
                ScannerPort.Parity = Properties.Settings.Default.ScannerParity;
                ScannerPort.ReadTimeout = Properties.Settings.Default.ScannerReadTimeout;
                ScannerPort.DtrEnable = Properties.Settings.Default.ScannerDtrEnable;
                ScannerPort.RtsEnable = Properties.Settings.Default.ScannerRtsEnable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to initialize scanner.  The error message received will be shown next.  You should close this program and try again.  If the problem persists, please contact support.", "Error initializing scanner");
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }
