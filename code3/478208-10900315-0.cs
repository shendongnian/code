    using System;
    using System.Windows.Forms;
    
    namespace MouseHoverDelay
    {
    	public class HoverButton : Button
    	{
    		protected System.Timers.Timer timer;
    
    		public bool IsHoverEnabled { get; set; }
    		public double Delay { get; set; }
    
    		public event System.Timers.ElapsedEventHandler TimerElapsed
    		{
    		    add
    		    {
    				timer.Elapsed += value;
    		    }
    		    remove
    		    {
    				timer.Elapsed -= value;
    		    }
    		}
    
    		public HoverButton()
    		{
    			// defaults: hover trigger enabled with 3000 ms delay
    			IsHoverEnabled = true;
    			Delay = 3000;
    
    			timer = new System.Timers.Timer
    			{
    				AutoReset = false,
    				Interval = Delay
    			};
    		}
    
    		protected override void OnMouseEnter(EventArgs e)
    		{
    			base.OnMouseEnter(e);
    
    			if (IsHoverEnabled)
    			{
    				timer.Start();
    			}
    		}
    
    		protected override void OnMouseLeave(EventArgs e)
    		{
    			base.OnMouseLeave(e);
    
    			timer.Stop();
    		}
    	}
    }
