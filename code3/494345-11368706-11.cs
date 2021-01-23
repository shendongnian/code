    private bool WaitForDocumentCompleted()
    		{
    			Thread.SpinWait(1000);  //This is dirty but working
    			while (Program.BrowsingSystem.IsBusy) //BrowsingSystem is another link to Browser that is made public in my Form and IsBusy is just a bool put to TRUE when Navigating event is raised and but to False when the DocumentCOmpleted is fired.
    			{
    				Application.DoEvents();
    				Thread.SpinWait(1000);
    			}
    			
    			if (Program.BrowsingSystem.IsInfoAvailable)  //IsInfoAvailable is just a get property to cover webBroweser.Document inside a lock statement to protect from concurrent accesses.
    			{
    				return true;
    			}
    			else
    				return false;
    		}
