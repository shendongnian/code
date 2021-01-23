    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Xml.Linq;
    using System.Drawing;
    using System.Windows.Forms;
    
    using System.ComponentModel;
    
    /// <summary>
    /// This Program Created by: SourceHints.com
    /// Nolan F. Sunico - SourceHints Administrator
    /// You are free to use or modify this code
    /// but please visit our website for new articles
    /// </summary>
    /// <DateCreated>November 30, 2011</DateCreated>
    /// <TimeCreated>3:43 PM</TimeCreated>
    /// <remarks></remarks>
    public partial class TransparentLabel
    {
    	public TransparentLabel()
    	{
    
    		// This call is required by the designer.
    		InitializeComponent();
    
    		// Add any initialization after the InitializeComponent() call.
    		// Add any initialization after the InitializeComponent() call.
    		this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    		this.SetStyle(ControlStyles.Opaque, true);
    		this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    		this.components = new System.ComponentModel.Container();
    		RF = new RectangleF(0, 0, base.Width, base.Height);
    		LabelForeColorBrush = new SolidBrush(base.ForeColor);
    	}
    #region Private
    	private StringFormat sFormat;
    	private RectangleF RF;
    	private SolidBrush LabelForeColorBrush = null;
    #endregion
    #region Subroutines
    	/// <summary>
    	/// Updates Text of this control.
    	/// </summary>
    	/// <remarks></remarks>
    	private void UpdateText()
    	{
    		try
    		{
    			sFormat = new StringFormat();
    			int x = 0;
    			int y = 0;
    //INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
    //				Select Case TextAlignment
    //ORIGINAL LINE: Case ContentAlignment.BottomCenter
    			if (TextAlignment == ContentAlignment.BottomCenter)
    			{
    			sFormat.Alignment = StringAlignment.Center;
    			sFormat.LineAlignment = StringAlignment.Far;
    			}
    //ORIGINAL LINE: Case ContentAlignment.BottomLeft
    			else if (TextAlignment == ContentAlignment.BottomLeft)
    			{
    			sFormat.Alignment = StringAlignment.Near;
    			sFormat.LineAlignment = StringAlignment.Far;
    			}
    //ORIGINAL LINE: Case ContentAlignment.BottomRight
    			else if (TextAlignment == ContentAlignment.BottomRight)
    			{
    			sFormat.Alignment = StringAlignment.Far;
    			sFormat.LineAlignment = StringAlignment.Far;
    			}
    //ORIGINAL LINE: Case ContentAlignment.MiddleLeft
    			else if (TextAlignment == ContentAlignment.MiddleLeft)
    			{
    			sFormat.Alignment = StringAlignment.Near;
    			sFormat.LineAlignment = StringAlignment.Center;
    			}
    //ORIGINAL LINE: Case ContentAlignment.MiddleCenter
    			else if (TextAlignment == ContentAlignment.MiddleCenter)
    			{
    			sFormat.Alignment = StringAlignment.Center;
    			sFormat.LineAlignment = StringAlignment.Center;
    			}
    //ORIGINAL LINE: Case ContentAlignment.MiddleRight
    			else if (TextAlignment == ContentAlignment.MiddleRight)
    			{
    			sFormat.Alignment = StringAlignment.Far;
    			sFormat.LineAlignment = StringAlignment.Center;
    			}
    //ORIGINAL LINE: Case ContentAlignment.TopCenter
    			else if (TextAlignment == ContentAlignment.TopCenter)
    			{
    			sFormat.Alignment = StringAlignment.Center;
    			sFormat.LineAlignment = StringAlignment.Near;
    			}
    //ORIGINAL LINE: Case ContentAlignment.TopLeft
    			else if (TextAlignment == ContentAlignment.TopLeft)
    			{
    			sFormat.Alignment = StringAlignment.Near;
    			sFormat.LineAlignment = StringAlignment.Near;
    			}
    //ORIGINAL LINE: Case ContentAlignment.TopRight
    			else if (TextAlignment == ContentAlignment.TopRight)
    			{
    			sFormat.Alignment = StringAlignment.Far;
    			sFormat.LineAlignment = StringAlignment.Near;
    			}
    			sFormat.FormatFlags = StringDirection;
    			ResizeControl();
    		}
    		catch (Exception ex)
    		{
    
    		}
    	}
    	/// <summary>
    	/// Resizes Transparent Label Control.
    	/// </summary>
    	/// <remarks></remarks>
    	private void ResizeControl()
    	{
    		RF.Size = new Size(base.Size);
    		Invalidate();
    	}
    #endregion
    #region Properties
    	private StringFormatFlags _StringDirection = StringFormatFlags.NoClip;
    	[Description("The Direction of the Text."), DefaultValue(StringFormatFlags.NoClip)]
    	public StringFormatFlags StringDirection
    	{
    		get
    		{
    			return _StringDirection;
    		}
    		set
    		{
    			_StringDirection = value;
    			UpdateText();
    		}
    	}
    
    	private System.Drawing.ContentAlignment _TextAlignment = ContentAlignment.MiddleCenter;
    	[Description("The Text Alignment that will appear on this control."), DefaultValue(ContentAlignment.MiddleCenter)]
    	public System.Drawing.ContentAlignment TextAlignment
    	{
    		get
    		{
    			return _TextAlignment;
    		}
    		set
    		{
    			_TextAlignment = value;
    			UpdateText();
    		}
    	}
    
    #endregion
    #region Overrides
    	public override System.Drawing.Color ForeColor
    	{
    		get
    		{
    			return base.ForeColor;
    		}
    		set
    		{
    			base.ForeColor = value;
    			LabelForeColorBrush = new SolidBrush(value);
    		}
    	}
    	/// <summary>
    	/// The text to be displayed in supports with real transparency.
    	/// </summary> 
    	/// <remarks></remarks>
    	private string _Labeltext = "TransparentLabel";
    	[Description("The text to be displayed in supports with real transparency."), Category("Text"), DefaultValue("TransparentLabel")]
    	public string LabelText
    	{
    		get
    		{
    			return _Labeltext;
    		}
    		set
    		{
    			_Labeltext = value;
    			Invalidate();
    		}
    	}
    
    	[Browsable(false), EditorBrowsable(false)]
    	public override System.Drawing.Color BackColor
    	{
    		get
    		{
    			return base.BackColor;
    		}
    		set
    		{
    			base.BackColor = value;
    		}
    	}
    	protected override System.Windows.Forms.CreateParams CreateParams
    	{
    		get
    		{
    			CreateParams cp = base.CreateParams;
    			cp.ExStyle = cp.ExStyle | 0x20;
    			return cp;
    		}
    	}
    	protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    	{
    		try
    		{
    			base.OnPaint(e);
    			// draw the text on the control
    			e.Graphics.DrawString(LabelText, base.Font, LabelForeColorBrush, RF, sFormat);
    			// MyBase.OnPaint(e)
    		}
    		catch (Exception ex)
    		{
    
    		}
    
    	}
    #endregion
    	private void TransparentLabel_Resize(object sender, System.EventArgs e)
    	{
    		ResizeControl();
    	}
    }
