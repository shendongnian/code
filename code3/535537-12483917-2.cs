    namespace Your.App
    {
    	public class GuardedCommand
    	{
    		public bool CurrentlyEditing { get; set; }
    		public GuardedCommand()
    		{
    			CurrentlyEditing = false;
    		}
    		public void DoCopy()
    		{
    			if(CurrentlyEditing)
    				StandardCopyCommand();
    			else
    				ShortcutCopyCommand();
    		}
    		void ShortcutCopyCommand() { /*menu work here (or delegate to another class)*/ }
    		void StandardCopyCommand() { /*"normal" work here (or delegate again)*/ }
    	}
    }
