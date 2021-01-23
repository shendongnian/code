    var form = new YourForm();
    form.Show(); // NOT BLOCKING!
    form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
    form.ClientSize = new System.Drawing.Size(200, 50);
    form.StartPosition = FormStartPosition.CenterParent;
    Label popupLabel1 = new Label();
    form.Controls.Add(popupLabel1);
