    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Net;
    using System.Windows.Forms;
    using System.Net.NetworkInformation;
    
    
    
    namespace DXWindowsApplication4
    {
    	public partial class Form2 : Form
    	{
    		private readonly Timer _timer;
    		private readonly Ping _pingClass;
    		private readonly IPAddress _ipAddress;
    		private readonly int _timeout;
    
    		private Image _greenImage; 
    		private Image _yellowImage; 
    		private Image _redImage; 
    
    		private int _pingCount;
    		private long _avgRtt;
    
    		public Form2()
    		{
    			InitializeComponent();
    			IPAddress.TryParse("98.138.253.109", out _ipAddress); // yahoo.com Ip address
    			_timer = new Timer();
    			_timeout = 3000;
    			_pingClass = new Ping();
    			_pingClass.PingCompleted += PingClassPingCompleted;
    		}
    
    		void PingClassPingCompleted(object sender, PingCompletedEventArgs e)
    		{
    			RefreshPing(e.Reply);
    		}
    
    		public void FormLoad(object sender, EventArgs e)
    		{
    			_timer.Tick += TimerTick;
    			_timer.Interval = 4000;
    			_timer.Start();
    		}
    
    		private void TimerTick(object sender, EventArgs e)
    		{
    			_pingClass.SendAsync(_ipAddress, _timeout);
    		}
    
    		private void RefreshPing(PingReply pingReply)
    		{
    			label4.Text = (pingReply.RoundtripTime.ToString(CultureInfo.InstalledUICulture));
    			label5.Text = (pingReply.Status.ToString());
    
    			_avgRtt = (_avgRtt * _pingCount++ + pingReply.RoundtripTime)/_pingCount;
    
    			if (Convert.ToInt32(label4.Text) > 0 && Convert.ToInt32(label4.Text) < 100)
    			{
    				SetImage(pictureBox1, Images.Green);
    			}
    
    			if (Convert.ToInt32(label4.Text) > 100 && Convert.ToInt32(label4.Text) < 200)
    			{
    				SetImage(pictureBox1, Images.Yellow);
    			}
    
    			if (Convert.ToInt32(label4.Text) > 200 && Convert.ToInt32(label4.Text) < 1000)
    			{
    				SetImage(pictureBox1, Images.Red);
    			}
    
    			ToolTip tt = new ToolTip();
    			tt.SetToolTip(pictureBox1, "Your average network delay is " + _avgRtt + "ms");
    			Refresh();
    		}
    
    		private void SetImage(PictureBox pBox, Images images)
    		{
    			switch (images)
    			{
    				case Images.Green:
    					if (_greenImage == null)
    					{
    						_greenImage = new Bitmap("greenImage.png");
    					}
    
    					pictureBox1.Image = _greenImage;
    					break;
    				case Images.Yellow:
    					if (_greenImage == null)
    					{
    						_yellowImage = new Bitmap("yellowImage.png");
    					}
    
    					pictureBox1.Image = _yellowImage;
    					break;
    				case Images.Red:
    					if (_redImage == null)
    					{
    						_redImage = new Bitmap("redImage.png");
    					}
    
    					pictureBox1.Image = _greenImage;
    					break;
    				default:
    					throw new InvalidEnumArgumentException("invalid enum name");
    			}
    		}
    	}
    
    	internal enum Images
    	{
    		Green,
    		Yellow,
    		Red
    	}
    }
