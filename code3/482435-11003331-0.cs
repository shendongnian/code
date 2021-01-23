    public class WaitForUserProcedureImpl : IWaitForUserProcedure
    {
    	public void DoSomething(Action pause)
    	{
    		// do stuff
    		pause(); // pause
    		// do more stuff
    		// ....
    		pause();
    	}
    }
    
    public class MainWindow: Window
    {
    
    	private void button_click(object sender)
    	{
    		WaitForUserProcedureImpl proc = new WaitForUserProcedureImpl();
    		Action myPauseAction = new Action(
    			()=>
    			{
    				MessageBox.Show("Press ok to continue","Press ok to continue",MessageBoxButtons.OK);
    			}
    		);
    		proc.DoSomething(myPauseAction);
    	}
    }
