    public void RemakeGrid()
    {
        this.ClearGrid();
        for(int c = 0; c < this.Columns; ++c)
        {
            for(int r = 0; r < this.Rows; ++r)
            {
                HexCell h = new HexCell();
                h.Width = 200;
                h.Height = 200;
                h.Location = new System.Drawing.Point(c*200, r*200);
                this.Controls.Add(h);
            }
        }
    }
    private int m_rows;
    [Browsable(true), DescriptionAttribute("Hexagonal grid row count."), Bindable(true)]
    public int Rows
    {
        get
        {
            return m_rows;
        }
        set
        {
            m_rows = value;
            this.RemakeGrid();
        }
    }
    // Same goes for Columns...
