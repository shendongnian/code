    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class WinFormsDropShadow: Form
    {
    	public static void Main()
    	{
    		Application.Run(new WinFormsDropShadow());
    	}
    	public WinFormsDropShadow()
    	{
    		Text = "Windows Forms Drop Shadow";
    		BackColor = Color.White;
    		Size = new Size(640, 480);
    	}
    	protected override void OnPaint(PaintEventArgs args)
    	{
    		Graphics grfx = args.Graphics;
    		Font fnt = new Font("Arial Black", 96);
    		string str = "Shadow";
    
    		grfx.DrawString(str, fnt, Brushes.Gray, grfx.DpiX / 12, grfx.DpiY / 12);
    		grfx.DrawString(str, fnt, Brushes.Black, 0, 0);
    	}
    }
