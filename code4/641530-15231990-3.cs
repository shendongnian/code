    public partial class Form1 : Form
    {
      public Form1()
      {
        InitializeComponent();
      }
      const int RowCount = 6;
      const int ColumnCount = 8;
      private void button1_Click(System.Object sender, System.EventArgs e)
      {
        for (int i = 0; i < RowCount; i++)
        {
          for (int j = 0; j < ColumnCount; j++)
          {
            Label lbl = new Label();
            lbl.Size = new Size(20, 20);
            lbl.Location = new Point(i * 20, j * 20);
            lbl.BackColor = (i + j) % 2 == 0 ? Color.Black : Color.White;
            lbl.Click += lbl_Click;
            panel1.Controls.Add(lbl);
          }
        }
        MessageBox.Show(CountCellsOfColor(Color.Black).ToString());
      }
      private int CountCellsOfColor(Color color)
      {
        int count = 0;
        foreach (Label lbl in panel1.Controls.OfType<Label>())
        {                
          if (lbl.BackColor == color) count += 1;
        }
        return count;
      }
      private void lbl_Click(object sender, System.EventArgs e)
      {
        Label lbl = (Label)sender;
        Color color = lbl.BackColor;
        if (color == System.Drawing.Color.Black)
        {
          color = System.Drawing.Color.White;
        }
        else
        {
          color = System.Drawing.Color.Black;
        }
        lbl.BackColor = color;
      }   
    }     
