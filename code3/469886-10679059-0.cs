	public class DataGridViewFileColumn : DataGridViewColumn
	{
		public DataGridViewFileColumn() : base(new DataGridViewFileCell())
		{
			BrowseLabel = "...";
			SaveFullPath = false;
		}
		public override DataGridViewCell CellTemplate
		{
			get
			{
				return base.CellTemplate;
			}
			set
			{
				// Ensure that the cell used for the template is a DataGridViewFileCell.
				if (value != null &&
					!value.GetType().IsAssignableFrom(typeof(DataGridViewFileCell)))
				{
					throw new InvalidCastException("Must be a DataGridViewFileCell");
				}
				base.CellTemplate = value;
			}
		}
		[Description("Label to place on Browse button"),Category("Appearance")]
		[DefaultValue("...")]
		public string BrowseLabel 
		{
			get; 
			set; 
		}
		[Description("Save full path name"), Category("Behavior")]
		[DefaultValue(true)]
		public bool SaveFullPath
		{
			get;
			set;
		}
	}
	public class DataGridViewFileCell : DataGridViewTextBoxCell
	{
		public DataGridViewFileCell() : base()
		{
		}
		public override void InitializeEditingControl(int rowIndex, object
				initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
		{
			// Set the value of the editing control to the current cell value.
			base.InitializeEditingControl(rowIndex, initialFormattedValue,
				dataGridViewCellStyle);
			FileEditingControl ctl = (FileEditingControl)DataGridView.EditingControl;
			// Use the default row value when Value property is null.
			if (this.Value == null)
			{
				ctl.Filename = this.DefaultNewRowValue.ToString();
			}
			else
			{
				ctl.Filename = this.Value.ToString();
			}
		}
		
		public override Type EditType
		{
			get
			{
				// Return the type of the editing control that DataGridViewFileCell uses.
				return typeof(FileEditingControl);
			}
		}
		public override Type ValueType
		{
			get
			{
				// Return the type of the value that DataGridViewFileCell contains.
				return typeof(string);
			}
		}
	}
	class FileEditingControl : FileTextBox, IDataGridViewEditingControl
	{
		DataGridView dataGridView;
		private bool valueChanged = false;
		int rowIndex;
		public FileEditingControl()
		{
		}
		#region IDataGridViewEditingControl implementations
		public object EditingControlFormattedValue
		{
			get
			{
				return Filename;
			}
			set
			{
				if (value is String)
				{
					try
					{
						Filename = (String)value;
					}
					catch
					{
						Filename = value.ToString();
					}
				}
			}
		}
		public object GetEditingControlFormattedValue(
			DataGridViewDataErrorContexts context)
		{
			return EditingControlFormattedValue;
		}
		public void ApplyCellStyleToEditingControl(
			DataGridViewCellStyle dataGridViewCellStyle)
		{
			this.Font = dataGridViewCellStyle.Font;
		}
		public int EditingControlRowIndex
		{
			get
			{
				return rowIndex;
			}
			set
			{
				rowIndex = value;
			}
		}
		public bool EditingControlWantsInputKey(
			Keys key, bool dataGridViewWantsInputKey)
		{
			switch (key & Keys.KeyCode)
			{
				case Keys.Left:
				case Keys.Up:
				case Keys.Down:
				case Keys.Right:
				case Keys.Home:
				case Keys.End:
				case Keys.PageDown:
				case Keys.PageUp:
					return true;
				default:
					return !dataGridViewWantsInputKey;
			}
		}
		public void PrepareEditingControlForEdit(bool selectAll)
		{
		}
		public bool RepositionEditingControlOnValueChange
		{
			get
			{
				return false;
			}
		}
		public DataGridView EditingControlDataGridView
		{
			get
			{
				return dataGridView;
			}
			set
			{
				dataGridView = value;
			}
		}
		public bool EditingControlValueChanged
		{
			get
			{
				return valueChanged;
			}
			set
			{
				valueChanged = value;
			}
		}
		public Cursor EditingPanelCursor
		{
			get
			{
				return base.Cursor;
			}
		}
		#endregion
		protected override void OnValueChanged(FileEventArgs eventargs)
		{
			// Notify the DataGridView that the contents of the cell
			// have changed.
			valueChanged = true;
			this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
			base.OnValueChanged(eventargs);
		}
	}
	public partial class FileTextBox : UserControl
	{
		#region Constructors
		public FileTextBox()
		{
			InitializeComponent();
			Tooltip = new ToolTip();
			SaveFullPath = false;
			AllowMultipleFiles = false;
			BrowseLabel = "...";
		}
		#endregion Constructors
		#region Properties
		/// <summary>
		/// Tooltip object used to show full path name
		/// </summary>
		private ToolTip Tooltip;
		/// <summary>
		/// Return the full path or just the filename?
		/// </summary>
		[Description("Save Full Path"), Category("Behavior")]
		[DefaultValue(false)]
		public bool SaveFullPath
		{
			get;
			set;
		}
		/// <summary>
		/// String representing the filename for this control
		/// </summary>
		public override string Text
		{
			get 
			{ 
				return base.Text; 
			}
			set 
			{
				if (base.Text != value)
				{
					base.Text = value;
					Tooltip.SetToolTip(this, base.Text);
					Invalidate();
					OnValueChanged(new FileEventArgs(base.Text));
				}
			}
		}
		[Description("Browse Label"), Category("Appearance")]
		[DefaultValue("...")]
		public string BrowseLabel
		{
			get
			{
				return Browse.Text;
			}
			set
			{
				Browse.Text = value;
				Browse.Width = TextRenderer.MeasureText(Browse.Text, Browse.Font).Width + 8;
				Browse.Location = new Point(this.Width - Browse.Width, Browse.Location.Y);
			}
		}
		[Description("Allow Multiple Files"), Category("Behavior")]
		[DefaultValue(false)]
		public bool AllowMultipleFiles
		{
			get;
			set;
		}
		/// <summary>
		/// Selected filename (same as Text property)
		/// </summary>
		[Description("Filename"), Category("Data")]
		public string Filename
		{
			get { return Text; }
			set { Text = value; }
		}
		#endregion Properties
		#region Event Handlers
		/// <summary>
		/// Event raised when 
		/// </summary>
		public event EventHandler ValueChanged;
		protected virtual void OnValueChanged(FileEventArgs eventargs)
		{
			eventargs.Filename = Filename;
			if (this.ValueChanged != null)
				this.ValueChanged(this, eventargs);
		}
		private void Browse_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.FileName = Text;
			dlg.Multiselect = AllowMultipleFiles;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				if (SaveFullPath)
					Text = dlg.FileName;
				else
					Text = dlg.SafeFileName;
			}
		} 
		protected override void OnPaint(PaintEventArgs e)
		{
			// Draw the client window
			Rectangle r = new Rectangle(new Point(0, 0), new Size(Size.Width-1, Size.Height-1));
			Graphics g = e.Graphics;
			g.FillRectangle(new SolidBrush(SystemColors.Window), r);
			g.DrawRectangle(new Pen(VisualStyleInformation.TextControlBorder), r);
			r.Y += Margin.Top;
			r.Width -= Browse.Width;
			// Fill with Text
			TextRenderer.DrawText(g, Text, Font, r, ForeColor, TextFormatFlags.PathEllipsis);
			base.OnPaint(e);
		}
		private void FileTextBox_DragDrop(object sender, DragEventArgs e)
		{
			DataObject data = (DataObject)e.Data;
			StringCollection filenames = data.GetFileDropList();
			if ( filenames.Count == 1)
				Text = filenames[0];
		}
		private void FileTextBox_DragEnter(object sender, DragEventArgs e)
		{
			DataObject data = (DataObject)e.Data;
			StringCollection filenames = data.GetFileDropList();
			if (/*!AllowMultipleFiles &&*/ filenames.Count == 1)
				e.Effect = DragDropEffects.Link;
		}
		#endregion Event Handlers
	}
	public class FileEventArgs : EventArgs
	{
		public FileEventArgs(string Text)
		{
			Filename = Text;
		}
		/// <summary>
		/// Name of the file in the control
		/// </summary>
		public String Filename { get; set; }
	}
