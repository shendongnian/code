      bool formClosing = false;
        private void Connection_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
          if (formClosing) return;
          _buffer = Connection.ReadExisting();
          Invoke(new EventHandler(AddReceivedPacketToTextBox));
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
          base.OnFormClosing(e);
          if (formClosing) return;
          e.Cancel = true;
          Timer tmr = new Timer();
          tmr.Tick += Tmr_Tick;
          tmr.Start();
          formClosing = true;
        }
        void Tmr_Tick(object sender, EventArgs e)
        {
          ((Timer)sender).Stop();
          this.Close();
        }
