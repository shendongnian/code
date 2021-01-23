    // Check if the user has Adobe Reader installed, if not you could show a link to Adobe Reader installer
    if (Type.GetTypeFromProgID("AcroPDF.PDF") == null)
	{
		pnlGetAdobe.Visible = pnlGetAdobe.Enabled = true;
	}
	else
	{
		try
		{
			// Initialize the Adobe control
			axAcroPDF1 = new AxAcroPDF();
			axAcroPDF1.Dock = DockStyle.Fill;
			axAcroPDF1.Enabled = true;
			axAcroPDF1.Location = new Point(0, 25);
			axAcroPDF1.Name = "axAcroPDF1";
			axAcroPDF1.OcxState = (AxHost.State)new ComponentResourceManager(typeof(JasperPdfReport)).GetObject("axAcroPDF1.OcxState");
			axAcroPDF1.Size = new Size(634, 393);
			axAcroPDF1.TabIndex = 1;
			pnlCenter.Controls.Add(axAcroPDF1); // Add it to a container or instead directly to your form with this.Controls.Add(axAcroPDF1)
			axAcroPDF1.BringToFront();
		}
		catch (COMException cex)
		{
			axAcroPDF1.Dispose();
			axAcroPDF1 = null;
			MessageBox.Show(cex.ToString());
		}
		catch (Exception ex)
		{
			axAcroPDF1.Dispose();
			axAcroPDF1 = null;
			MessageBox.Show(ex.ToString());
		}
	}
