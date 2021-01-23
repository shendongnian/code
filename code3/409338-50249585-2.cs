   			if(dcdEvent.IsListening)
			{
				dcdEvent.StopScanListener();
			}
            
            if (hDcd != null)
            {
                hDcd.Dispose();
            }
 
