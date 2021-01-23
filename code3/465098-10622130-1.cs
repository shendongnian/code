    int pair_req = 0;
    try
    {
    	if (BluetoothSecurity.SetPin(device, "0000")) {
    		while (status == false && pair_req < 3)
    		{
    			++pair_req;
    			status_box.Text = status_box.Text + '\n' + "Attempt " + pair_req.ToString();
    			status_box.Update();
    			
    
    			if (BluetoothSecurity.PairRequest(device, "0000"))
    			{
    				status = true;
    				client.Refresh();
    				status_box.Text = "Paired Successfully.";
    				status_box.Update();
    				Thread.Sleep(5000);
    			}
    			else
    			{
    				status = false;
    
    			}
    			
    		}
    	}
    }
    catch (ArgumentNullException e)
    {
    	status_box.Text = "Pair failed.";
    	status_box.Update();
    	Thread.Sleep(5000);
    }
    
    status_box.Update();
    Thread.Sleep(400);
