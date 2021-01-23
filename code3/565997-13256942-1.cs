     public void SendEndianBinaryMsg(Stream ns, byte[] msg)
        {
            byte size = (byte)msg.Length;
            try
            {
               
                EndianBinaryWriter writer = new EndianBinaryWriter(EndianBitConverter.Big, ns);
                writer.Write(size); 
                writer.Write(msg); 
                writer.Flush();
                ns.Close();
            }
            catch (ArgumentNullException ane)
            {
                TextBox.Text += "ArgumentNullException : {0}" + ane.ToString();
            }
            catch (Exception e)
            {
                TextBox.Text += ("Unexpected exception : {0}" + e.ToString());
            }
        }
