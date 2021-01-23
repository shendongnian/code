    static class program
    {
      static void Main()
      {
        System.Windows.Forms.Application.Run(new frmMain());
      }
    }
    public class frmMain : Form
    {
      private System.Windows.Forms.Label lblText;
      private System.Windows.Forms.Button btnLoadText;
		
      public frmMain()
      {
        InitializeComponent();
      }
	
      private void InitializeComponent()
      {
        this.lblText = new System.Windows.Forms.Label();
        this.lblText.AutoSize = true;
        this.lblText.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblText.Location = new System.Drawing.Point(0, 0);
        this.lblText.Name = "lblText";
        this.lblText.Size = new System.Drawing.Size(170, 24);
        this.lblText.TabIndex = 0;
        this.lblText.Text = "";
        this.Controls.Add(this.lblText);
			
        this.btnLoadText = new System.Windows.Forms.Button();
        this.btnLoadText.Location = new System.Drawing.Point(339, 24);
        this.btnLoadText.Name = "btnLoadText";
        this.btnLoadText.Size = new System.Drawing.Size(75, 23);
        this.btnLoadText.TabIndex = 29;
        this.btnLoadText.Text = "Load Text";
        this.btnLoadText.UseVisualStyleBackColor = true;
        this.btnLoadText.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.Controls.Add(this.btnLoadText);
        this.btnLoadText.Click += new System.EventHandler(this.btnLoadText_Click);			
      }
      private void btnLoadText_Click(object sender, EventArgs e)
      {
        StreamReader streamReader = new StreamReader("test.txt");
        string text = streamReader.ReadToEnd();
        streamReader.Close();
        this.lblText.Text = text;
      }
    }
