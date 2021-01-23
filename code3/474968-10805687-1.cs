    public frmDlgGraphOptions()
    {
      InitializeComponent();
      CmbBoxlineStyles.DropDownStyle = ComboBoxStyle.DropDownList;
      CmbBoxlineStyles.DrawMode = DrawMode.OwnerDrawFixed;
      CmbBoxlineStyles.DrawItem += CmbBoxlineStyles_DrawItem;
    }
    void CmbBoxlineStyles_DrawItem(object sender, DrawItemEventArgs e) {
      // draw
    }
