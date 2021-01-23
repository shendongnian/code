            port.Write(new byte[] { 0x11, 0x43, 0x0D}, 0, 3);
            byte[] buffer1 = new byte[] {0x11, 0x43, 0x0D };
            LogSent(LogMsgType.Outgoing, DateTime.Now + "  --  " + ByteArrayToHexString(buffer1) + "\n");
        }
      
        private Color[] LogMsgTypeColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };
        
        public enum LogMsgType { Incoming, Outgoing, Normal, Warning, Error };
        void port_DataReceivedBIT(object sender, SerialDataReceivedEventArgs e)
        {
                //port.Open();
                this.Invoke(new EventHandler(AddReceiveBIT));
           
        }
    
        private void AddReceiveBIT ( object s, EventArgs e)
        {
                Thread.Sleep(100);
                byte[] buffer = new byte[port.BytesToRead];
                port.Read(buffer, 0, buffer.Length);
               
                LogReceive(LogMsgType.Incoming, DateTime.Now + "  --  " + ByteArrayToHexString(buffer) + "\n");
                Log(LogMsgType.Incoming, checkBit(buffer) + "\n");
            }
        private string checkBit(byte[] buffer)
        {
            StringBuilder message = new StringBuilder();
            var responseByte = buffer[7];
            if ((responseByte & (1 << 0)) == 0)
            {
                message.AppendFormat("rezerved                                                                            ok    ");
            }
            else
            {
                message.AppendFormat("rezerved                                                                          error    ");
            }
            if ((responseByte & (1 << 1)) == 0)
            {
                message.AppendFormat("rezerved                                                                            ok   ");
            }
            else
            {
                message.AppendFormat("rezerved                                                                          error   ");
            }
            if ((responseByte & (1 << 2)) == 0)
            {
                message.AppendFormat("rezerved                                                                            ok  ");
            }
            else
            {
                message.AppendFormat("rezerved                                                                          error  ");
            }
            if ((responseByte & (1 << 3)) == 0)
            {
                message.AppendFormat("rezerved                                                                            ok  ");
            }
            else
            {
                message.AppendFormat("rezerved                                                                          error  ");
            }
            if ((responseByte & (1 << 4)) == 0)
            {
                message.AppendFormat("rezerved                                                                            ok  ");
            }
            else
            {
                message.AppendFormat("rezerved                                                                          error  ");
            }
            if ((responseByte & (1 << 5)) == 0)
            {
                message.AppendFormat("rezerved                                                                            ok  ");
            }
            else
            {
                message.AppendFormat("rezerved                                                                          error  ");
            }
            if ((responseByte & (1 << 6)) == 0)
            {
                message.AppendFormat("Serial Communication                                                        ok  ");
            }
            else
            {
                message.AppendFormat("Serial Communication                                                              error  ");
            }
            if ((responseByte & (1 << 7)) == 0)
            {
                message.AppendFormat("Optical Zoom                                                                     ok ");
            }
            else
            {
                message.AppendFormat("Optical Zoom                                                                     error  ");
            }
            return message.ToString();
        }
        private string ByteArrayToHexString(byte[] PortBuffer)
        {
            StringBuilder sb = new StringBuilder(PortBuffer.Length * 3);
            foreach (byte b in PortBuffer)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
            
        }
        private void LogReceive(LogMsgType msgtype, string msg)
        {
            richTextBox1.Invoke(new EventHandler(delegate
            {
                richTextBox1.SelectedText = string.Empty;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold);
                richTextBox1.SelectionColor = LogMsgTypeColor[(int)msgtype];
                richTextBox1.AppendText(msg);
                richTextBox1.ScrollToCaret();
                
            }
            ));
        }
        private void LogSent(LogMsgType msgtype, string msg)
        {
            textBox2.Invoke(new EventHandler(delegate
            {
                textBox2.SelectedText = string.Empty;
                textBox2.AppendText(msg);
                textBox2.ScrollToCaret();
            }
            ));
        }
        private void Log(LogMsgType msgtype, string msg)
        {
            textBox3.Invoke(new EventHandler(delegate
            {
                textBox3.Clear();
                textBox3.SelectedText = string.Empty;
                textBox3.AppendText(msg);
                textBox3.ScrollToCaret();
            }
            ));
        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
