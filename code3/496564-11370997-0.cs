    public partial class ComponentMover : Form
    {
    	private Control trackedControl;
    	private int gridWidth = 100, gridHeight = 20;
    
    	public ComponentMover()
    	{
    		this.InitializeComponent();
    		this.InitializeDynamic();
    	}
    
    	void draggable_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    	{
    		if (this.trackedControl == null)
    			this.trackedControl = (Control)sender;
    	}
    
    	void draggable_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
    	{
    		if (this.trackedControl != null)
    		{
    			int x = e.X + this.trackedControl.Location.X;
    			int y = e.Y + this.trackedControl.Location.Y;
    			Point moved = new Point(x - x % this.gridWidth, y - y % this.gridHeight);
    
    			Console.WriteLine(e.X + ", " + e.Y + ", " + ", " + moved.X + ", " + moved.Y);
    			if (moved != this.trackedControl.Location)
    				this.trackedControl.Location = moved;
    		}
    	}
    
    	void draggable_MouseUp(object sender, MouseEventArgs e)
    	{
    		this.trackedControl = null;
    	}
    
    	private void AddDragListeners(Control draggable)
    	{
    		draggable.MouseDown += new MouseEventHandler(draggable_MouseDown);
    		draggable.MouseMove += new MouseEventHandler(draggable_MouseMove);
    		draggable.MouseUp += new MouseEventHandler(draggable_MouseUp);
    	}
    }
    // Designer code.
    partial class ComponentMover
    {
    	/// <summary>
    	/// Required designer variable.
    	/// </summary>
    	private System.ComponentModel.IContainer components = null;
    
    	/// <summary>
    	/// Clean up any resources being used.
    	/// </summary>
    	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    	protected override void Dispose(bool disposing)
    	{
    		if (disposing && (components != null))
    		{
    			components.Dispose();
    		}
    		base.Dispose(disposing);
    	}
    
    	private void InitializeDynamic()
    	{
    		this.AddDragListeners(button1);
    		this.AddDragListeners(button4);
    		this.AddDragListeners(domainUpDown1);
    		this.AddDragListeners(textBox1);
    		this.AddDragListeners(checkBox1);
    		this.AddDragListeners(radioButton1);
    			
    		//this.MouseMove += new System.Windows.Forms.MouseEventHandler(draggable_MouseMove);
    	}
    
    	#region Windows Form Designer generated code
    
    	/// <summary>
    	/// Required method for Designer support - do not modify
    	/// the contents of this method with the code editor.
    	/// </summary>
    	private void InitializeComponent()
    	{
    		this.button1 = new System.Windows.Forms.Button();
    		this.button4 = new System.Windows.Forms.Button();
    		this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
    		this.textBox1 = new System.Windows.Forms.TextBox();
    		this.checkBox1 = new System.Windows.Forms.CheckBox();
    		this.radioButton1 = new System.Windows.Forms.RadioButton();
    		this.SuspendLayout();
    		// 
    		// button1
    		// 
    		this.button1.Location = new System.Drawing.Point(13, 13);
    		this.button1.Name = "button1";
    		this.button1.Size = new System.Drawing.Size(75, 23);
    		this.button1.TabIndex = 0;
    		this.button1.Text = "button1";
    		this.button1.UseVisualStyleBackColor = true;
    		// 
    		// button4
    		// 
    		this.button4.Location = new System.Drawing.Point(177, 43);
    		this.button4.Name = "button4";
    		this.button4.Size = new System.Drawing.Size(75, 23);
    		this.button4.TabIndex = 3;
    		this.button4.Text = "button4";
    		this.button4.UseVisualStyleBackColor = true;
    		// 
    		// domainUpDown1
    		// 
    		this.domainUpDown1.Location = new System.Drawing.Point(95, 42);
    		this.domainUpDown1.Name = "domainUpDown1";
    		this.domainUpDown1.Size = new System.Drawing.Size(74, 20);
    		this.domainUpDown1.TabIndex = 4;
    		this.domainUpDown1.Text = "domainUpDown1";
    		// 
    		// textBox1
    		// 
    		this.textBox1.Location = new System.Drawing.Point(177, 72);
    		this.textBox1.Name = "textBox1";
    		this.textBox1.Size = new System.Drawing.Size(100, 20);
    		this.textBox1.TabIndex = 5;
    		// 
    		// checkBox1
    		// 
    		this.checkBox1.AutoSize = true;
    		this.checkBox1.Location = new System.Drawing.Point(281, 13);
    		this.checkBox1.Name = "checkBox1";
    		this.checkBox1.Size = new System.Drawing.Size(80, 17);
    		this.checkBox1.TabIndex = 6;
    		this.checkBox1.Text = "checkBox1";
    		this.checkBox1.UseVisualStyleBackColor = true;
    		// 
    		// radioButton1
    		// 
    		this.radioButton1.AutoSize = true;
    		this.radioButton1.Location = new System.Drawing.Point(366, 42);
    		this.radioButton1.Name = "radioButton1";
    		this.radioButton1.Size = new System.Drawing.Size(85, 17);
    		this.radioButton1.TabIndex = 7;
    		this.radioButton1.TabStop = true;
    		this.radioButton1.Text = "radioButton1";
    		this.radioButton1.UseVisualStyleBackColor = true;
    		// 
    		// ComponentMover
    		// 
    		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    		this.ClientSize = new System.Drawing.Size(485, 159);
    		this.Controls.Add(this.radioButton1);
    		this.Controls.Add(this.checkBox1);
    		this.Controls.Add(this.textBox1);
    		this.Controls.Add(this.domainUpDown1);
    		this.Controls.Add(this.button4);
    		this.Controls.Add(this.button1);
    		this.Name = "ComponentMover";
    		this.Text = "ComponentMover";
    		this.ResumeLayout(false);
    		this.PerformLayout();
    
    	}
    
    	#endregion
    
    	private System.Windows.Forms.Button button1;
    	private System.Windows.Forms.Button button4;
    	private System.Windows.Forms.DomainUpDown domainUpDown1;
    	private System.Windows.Forms.TextBox textBox1;
    	private System.Windows.Forms.CheckBox checkBox1;
    	private System.Windows.Forms.RadioButton radioButton1;
    }
