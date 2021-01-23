    public partial class Form1 : Form
    {
        bool resizing = false;
        TableLayoutRowStyleCollection rowStyles;
        TableLayoutColumnStyleCollection columnStyles;
        int colindex = -1;
        int rowindex = -1;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            rowStyles = tableLayoutPanel1.RowStyles;
            columnStyles = tableLayoutPanel1.ColumnStyles;
        }
        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                rowStyles = tableLayoutPanel1.RowStyles;
                columnStyles = tableLayoutPanel1.ColumnStyles;
                resizing = true;
            }
        }
        
        private void tableLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!resizing)
            {
                float width = 0;
                float height = 0;
                //for rows
                for (int i = 0; i < rowStyles.Count; i++)
                {
                    height += rowStyles[i].Height;
                    if (e.Y > height - 3 && e.Y < height + 3)
                    {
                        rowindex = i;
                        tableLayoutPanel1.Cursor = Cursors.HSplit;
                        break;
                    }
                    else
                    {
                        rowindex = -1;
                        tableLayoutPanel1.Cursor = Cursors.Default;
                    }
                }
                //for columns
                for (int i = 0; i < columnStyles.Count; i++)
                {
                    width += columnStyles[i].Width;
                    if (e.X > width - 3 && e.X < width + 3)
                    {
                        colindex = i;
                        if (rowindex > -1)
                            tableLayoutPanel1.Cursor = Cursors.Cross;
                        else
                            tableLayoutPanel1.Cursor = Cursors.VSplit;
                        break;
                    }
                    else
                    {
                        colindex = -1;
                        if (rowindex == -1)
                            tableLayoutPanel1.Cursor = Cursors.Default;
                    }
                }
            }
            if (resizing && (colindex>-1 || rowindex > -1))
            {
                float width = e.X;
                float height = e.Y;
                if (colindex > -1)
                {
                    for (int i = 0; i < colindex; i++)
                    {
                        width -= columnStyles[i].Width;
                    }
                    columnStyles[colindex].SizeType = SizeType.Absolute;
                    columnStyles[colindex].Width = width;
                }
                if (rowindex > -1)
                {
                    for (int i = 0; i < rowindex; i++)
                    {
                        height -= rowStyles[i].Height;
                    }
                    rowStyles[rowindex].SizeType = SizeType.Absolute;
                    rowStyles[rowindex].Height = height;
                }
            }
        }
        private void tableLayoutPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                resizing = false;
                tableLayoutPanel1.Cursor = Cursors.Default;
            }
        }
    }
