    using System;
    using System.Windows.Forms;
    using SKYPE4COMLib;
    
    namespace SkypeCall
    {
    	public partial class Form1 : Form
    	{
    		public Form1()
    		{
    			InitializeComponent();
    			InitializeSkype();
    		}
    
    		private void InitializeSkype()
    		{
    			s = new Skype();
    			_ISkypeEvents_Event events = s;
    
    			events.AttachmentStatus += OnAttachementStatusChanged;
    			events.CallStatus += OnCallStatusChanged;
    
    			s.Attach();
    		}
    
    		private void OnCallStatusChanged(Call call, TCallStatus status)
    		{
    			switch (status)
    			{
    				case TCallStatus.clsInProgress: break;
    				case TCallStatus.clsCancelled: break;
    				case TCallStatus.clsFinished: break;
    				case TCallStatus.clsRinging: break;
    				//.
    				//.
    				//.					
    			}
    
    
    			// call.PstnNumber;
    			// call.PstnStatus;
    		}
    
    		private void OnAttachementStatusChanged(TAttachmentStatus status)
    		{
    			if (status == TAttachmentStatus.apiAttachSuccess)
    			{
    				attached = true;
    			}
    		}
    
    
    		private Skype s;
    		private bool attached;
    	}
    }
