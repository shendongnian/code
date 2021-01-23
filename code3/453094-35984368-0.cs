    if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
    {
      Type dgvType = dataGridView1.GetType();
      PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
        BindingFlags.Instance | BindingFlags.NonPublic);
      pi.SetValue(dataGridView1, value, null);
    }
