    class FrmDelivery : Form
    {
    ListBox s;
    public FrmDelivery()
    {
        s = new ListBox();
        s.Location = new System.Drawing.Point(0, 0); //relative to the parent control (not an absolute value, so)
        s.Name = "listBox1";
        s.Size = new System.Drawing.Size(120, 95);
 
        s.DataSource = new List<int>(){1,2,3,4};
        this.Controls.Add(s); //it will add it to the form but you can add it to another control, like panel.
    }
