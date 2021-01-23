	/// <summary>
	/// Represents a Windows TextBox control that displays placeholder text when the
	/// control is empty.
	/// </summary>
	public class PlaceholderTextBox : TextBox
	{
		private bool _set;
		private Color _valueForeColor;
		private Color _valueBackColor;
		private Font _valueFont;
		private Color? _PlaceholderForeColor;
		private Color? _PlaceholderBackColor;
		private Font _PlaceholderFont;
		/// <summary>
		/// Gets or sets the text that is shown when the <see cref="TextBox"/> is empty.
		/// </summary>
		[Browsable(true)]
		[Category("Appearance")]
		[Description ("The text that is shown when the TextBox is empty.")]
		[DefaultValue("")]
		public string PlaceholderText { get; set; }
		/// <summary>
		/// Gets or sets the <see cref="Color"/> of the placeholder text.
		/// </summary>
		[Browsable(true)]
		[Category("Appearance")]
		[Description("The color of the placeholder text.")]
		public Color PlaceholderForeColor
		{
			get { return _PlaceholderForeColor ?? _valueForeColor; } 
			set
			{
				if (value == _valueForeColor)
					_PlaceholderForeColor = null;
				else
					_PlaceholderForeColor = value;
			}
		}
		/// <summary>
		/// Gets or sets the <see cref="Color"/> of the background when displaying placeholder text.
		/// </summary>
		[Browsable(true)]
		[Category("Appearance")]
		[Description("The color of the background when displaying placeholder text.")]
		public Color PlaceholderBackColor
		{
			get { return _PlaceholderBackColor ?? _valueBackColor; } 
			set
			{
				if (value == _valueBackColor)
					_PlaceholderBackColor = null;
				else
					_PlaceholderBackColor = value;
			}
		}
		/// <summary>
		/// Gets or sets the <see cref="Font"/> used by the control when displaying placeholder text.
		/// </summary>
		[Browsable(true)]
		[Category("Appearance")]
		[Description("the Font used by the control when displaying placeholder text.")]
		public Font PlaceholderFont
		{
			get { return _PlaceholderFont ?? Font; }
			set { _PlaceholderFont = value.Equals(Font) ? null : value; }
		}
		/// <summary>
		/// Gets or sets the foreground color of the control.
		/// </summary>
		/// <returns>
		/// A <see cref="Color"/> that represents the control's foreground color.
		/// </returns>
		public override Color ForeColor
		{
			get { _valueForeColor; }
			set
			{
				_valueForeColor = value;
				if(_set)
					base.ForeColor = value;
			}
		}
		/// <summary>
		/// Gets or sets the background color of the control.
		/// </summary>
		/// <returns>
		/// A <see cref="Color"/> that represents the background of the control.
		/// </returns>
		public override Color BackColor
		{
			get { return _valueBackColor; }
			set
			{
				_valueBackColor = value;
				if(_set)
					base.BackColor = value;
			}
		}
		/// <summary>
		/// Gets or sets the font of the text displayed by the control.
		/// </summary>
		/// <returns>
		/// The <see cref="Font"/> to apply to the text displayed by the control. 
		/// The default is the value of the <see cref="Control.DefaultFont"/> property.
		/// </returns>
		public override Font Font
		{
			get { return _valueFont; }
			set
			{
				_valueFont = value;
				if(_set)
					base.Font = value;
			}
		}
		
		public PlaceholderTextBox()
		{
			_valueForeColor = base.ForeColor;
			_valueBackColor = base.BackColor;
			_valueFont = base.Font;
		}
		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus"/> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
		protected override void OnGotFocus(EventArgs e)
		{
			if (!_set)
			{
				Text = String.Empty;
				base.ForeColor = _valueForeColor;
				base.BackColor = _valueBackColor;
				base.Font = _valueFont;
				_set = true;
			}
			
			base.OnGotFocus(e);
		}
		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus"/> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
		protected override void OnLostFocus(EventArgs e)
		{
			if (Text == String.Empty)
			{
				Text = PlaceholderText;
				base.ForeColor = PlaceholderForeColor;
				base.BackColor = PlaceholderBackColor;
				base.Font = PlaceholderFont;
				_set = false;
			}
			
			base.OnLostFocus(e);
		}
	}
