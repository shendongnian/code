			// Attempt to load a handle to the decoder.
			try
			{
				hDcd = new DecodeHandle(DecodeDeviceCap.Exists | DecodeDeviceCap.Barcode);
			}
			catch(DecodeException)
			{
				MessageBox.Show("Exception loading barcode decoder.", "Decoder Error");
				return;
			}
			// Now that we've got a connection to a barcode reading device, assign a
			// method for the DcdEvent.  A recurring request is used so that we will
			// continue to get barcode data until our dialog is closed.
			DecodeRequest reqType = (DecodeRequest)1 | DecodeRequest.PostRecurring;
            
			// Initialize all events possible
            //dcdEvent = new DecodeEvent(hDcd, reqType);
			dcdEvent = new DecodeEvent(hDcd, reqType, this);
			dcdEvent.Scanned += new DecodeScanned(dcdEvent_Scanned);
